using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_4_Email_Tool.Models;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using MimeKit;

namespace Course_4_Email_Tool.Controllers
{
	public class AccountController : Controller
	{
		private ImapClient _client = new ImapClient();

		public IActionResult Index()
		{
			return Redirect("/Index");
		}

		public IActionResult Login(LoginModel model)
		{
			try
			{
				_client.Connect(model.IMAP_HOST, 993, SecureSocketOptions.SslOnConnect);
			}
			catch (SocketException)
			{
				TempData["Invalid Credentials"] = "Unknown HOST";
			}

			try
			{
				_client.Authenticate(model.Email, model.Password);
				SaveConfig(new ConfigurationModel
				{
					Email = model.Email,
					Password = model.Password,
					IMAP_HOST = model.IMAP_HOST,
					INCOMING_PORT_IMAP = model.INCOMING_PORT_IMAP,
					OUTGOING_PORT_SMTP = model.OUTGOING_PORT_SMTP
				});
			}
			catch (AuthenticationException ex)
			{
				Console.WriteLine(ex.Message);
				TempData["Invalid Credentials"] = "Credentials were invalid, Please try again";
				Redirect("/Index");
			}

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
					Subject = message.Subject
				};

				var attachments = message.Attachments.ToList();

				foreach (var attachment in attachments)
				{
					using (var memory = new MemoryStream())
					{
						if (attachment is MimePart)
							((MimePart) attachment).Content.DecodeTo(memory);
						else
							((MessagePart) attachment).Message.WriteTo(memory);

						var bytes = memory.ToArray();

						var data = new Attachment
						{
							Name = attachment.ContentType.Name,
							Type = attachment.ContentType.MediaSubtype,
							ContentBase64 = bytes
						};
						mailToShow.AttachmentsList.Add(data);
					}
				}

				mails.Add(mailToShow);
			}

			return mails;
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