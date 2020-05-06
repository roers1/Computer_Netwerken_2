using System;
using System.Collections.Generic;
using System.Linq;
using Course_4_Email_Tool.Models;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using MailKit;
using MailKit.Search;
using Newtonsoft.Json;
using MimeKit;
using AttachmentCustom = Course_4_Email_Tool.Models.AttachmentCustom;

namespace Course_4_Email_Tool.Controllers
{
	public class AccountController : Controller
	{
		private ImapClient _client = new ImapClient();

		public IActionResult Index()
		{
			return Redirect("/Index");
		}

		public IActionResult Login(ConfigurationModel config)
		{
			SaveConfig(config);

			Authenticate();

			Console.WriteLine(_client.IsConnected);
			var mails = Inbox();

			return View("Inbox", mails);
		}

		public void SaveConfig(ConfigurationModel model)
		{
			var configModel = model;

			HttpContext.Session.Set("Config", configModel);
		}

		public IList<Mail> Inbox()
		{
			_client.Inbox.Open(FolderAccess.ReadOnly);
			var config = HttpContext.Session.Get<ConfigurationModel>("Config");

			int mailsToShow = _client.Inbox.Count > config.MailsToShow ? config.MailsToShow : _client.Inbox.Count();
			IList<Mail> mails = new List<Mail>();
			for (int i = 0; i < mailsToShow; i++)
			{
				var message = _client.Inbox.GetMessage(i);
				var mailToShow = new Mail
				{
					From = message.From.ToString(),
					To = message.To.ToString(),
					Message = message.HtmlBody,
					SendDate = message.Date,
					Subject = message.Subject,
					MessageId = message.MessageId
				};

				var attachments = message.Attachments.ToList();

				foreach (var attachment in attachments)
				{
					using var memory = new MemoryStream();
					var data = new AttachmentCustom
					{
						Name = attachment.ContentType.Name,
						Type = attachment.ContentType.MediaSubtype,
					};
					mailToShow.AttachmentsList.Add(data);
				}

				mails.Add(mailToShow);
			}

			return mails;
		}

		public IActionResult ReturnToInbox()
		{
			var config = HttpContext.Session.Get<ConfigurationModel>("Config");

			return RedirectToAction("Login", config);
		}

		public IActionResult Mail(string messageId)
		{
			return View(GetMail(messageId));
		}

		public Mail GetMail(string messageId)
		{
			Authenticate();

			_client.Inbox.Open(FolderAccess.ReadOnly);
			var uids = _client.Inbox.Search(SearchQuery.HeaderContains("Message-Id", messageId));

			var message = _client.Inbox.GetMessage(uids.ElementAt(0));

			var mailToShow = new Mail
			{
				From = message.From.ToString(),
				To = message.To.ToString(),
				Message = message.TextBody,
				SendDate = message.Date,
				Subject = message.Subject,
				MessageId = message.MessageId
			};

			var attachments = message.Attachments.ToList();

			foreach (var attachment in attachments)
			{
				using var memory = new MemoryStream();
				if (attachment is MimePart part)
					part.Content.DecodeTo(memory);
				else
					((MessagePart) attachment).Message.WriteTo(memory);

				var bytes = memory.ToArray();

				var data = new AttachmentCustom
				{
					Name = attachment.ContentType.Name,
					Type = attachment.ContentType.MediaSubtype,
					ContentBase64 = bytes
				};
				mailToShow.AttachmentsList.Add(data);
			}

			return mailToShow;
		}

		public IActionResult SaveAttachment(string messageId)
		{
			Authenticate();
			_client.Inbox.Open(FolderAccess.ReadOnly);
			var uids = _client.Inbox.Search(SearchQuery.HeaderContains("Message-Id", messageId));

			var message = _client.Inbox.GetMessage(uids.ElementAt(0));

			foreach (MimeEntity attachment in message.Attachments)
			{
				var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;

				using (var stream = System.IO.File.Create(fileName))
				{
					if (attachment is MessagePart)
					{
						var rfc822 = (MessagePart) attachment;

						rfc822.Message.WriteTo(stream);
					}
					else
					{
						var part = (MimePart) attachment;

						part.Content.DecodeTo(stream);
					}
				}
			}

			return View("Mail", GetMail(messageId));
		}

		public IActionResult Settings()
		{
			var config = HttpContext.Session.Get<ConfigurationModel>("Config");
			return View(config);
		}

		public IActionResult SaveSettings(ConfigurationModel model)
		{
			SaveConfig(model);
			return RedirectToAction("Login", model);
		}

		public IActionResult SendMail(SentMailModel mail)
		{
			var model = HttpContext.Session.Get<ConfigurationModel>("Config");

			var client = new SmtpClient(model.SMTP_HOST, model.OUTGOING_PORT_SMTP)
			{
				Credentials = new NetworkCredential(model.Email, model.Password),
				EnableSsl = true
			};

			MailMessage message = new MailMessage(model.Email,mail.To,mail.Subject,mail.Message);


			return RedirectToAction("Login", model);
		}

		public void Authenticate()
		{
			var model = HttpContext.Session.Get<ConfigurationModel>("Config");
			if (!_client.IsConnected)
			{
				try
				{
					_client.Connect(model.IMAP_HOST, model.INCOMING_PORT_IMAP, SecureSocketOptions.SslOnConnect);
				}
				catch (SocketException)
				{
					TempData["Invalid Credentials"] = "Unknown HOST";
				}
			}

			if (!_client.IsAuthenticated)
			{
				try
				{
					_client.Authenticate(model.Email, model.Password);

				}
				catch (AuthenticationException ex)
				{
					Console.WriteLine(ex.Message);
					TempData["Invalid Credentials"] = "Credentials were invalid, Please try again";
					Redirect("/Index");
				}
			}
		}
	}

	public static class SessionExtensions
	{
		public static void Set<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T Get<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				ObjectCreationHandling = ObjectCreationHandling.Replace
			};
			return value == null ? default : JsonConvert.DeserializeObject<T>(value, settings);
		}
	}
}