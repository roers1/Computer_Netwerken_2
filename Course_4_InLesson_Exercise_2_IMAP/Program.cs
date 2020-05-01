using MailKit.Net.Imap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MailKit;
using MailKit.Security;

namespace Course_4_InLesson_Exercise_IMAP_SMTP
{
	class Program
	{
		static void Main(string[] args)
		{
			var email = "";
			var password = "";
			IList mailCollection = new List<Email>();

			ImapClient ic = new ImapClient();
			ic.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

			Console.WriteLine("Login to your google mail: ");
			Console.Write("Enter E-mail: ");
			email = Console.ReadLine();
			Console.Write("Enter password: ");
			password = Console.ReadLine();
			Console.WriteLine();

			ic.Authenticate(email, password);

			ic.Inbox.Open(FolderAccess.ReadOnly);
			int mailsToShow = ic.Inbox.Count > 10 ? 10 : ic.Inbox.Count();


			for (int i = 0; i < mailsToShow; i++)
			{
				var message = ic.Inbox.GetMessage(i);
				var mailToShow = new Email
				{
					From = message.From[0].Name,
					Subject = message.Subject,
					Message = message.TextBody,
					HasAttachment = message.Attachments.Any()
				};

				mailCollection.Add(mailToShow);
			}

			foreach (Email mail in mailCollection)
			{
				Console.WriteLine("Mail from: " + mail.From);
				Console.WriteLine("Subject: " + mail.Subject);
				Console.WriteLine("Message: " + mail.Message);
			}

			Console.Write("Press enter to quit...");
			Console.ReadLine();
		}
	}
}