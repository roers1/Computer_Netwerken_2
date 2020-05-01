using System;
using System.Net;
using System.Net.Mail;

namespace Course_4_InLesson_Exercise_3_SMTP
{
	class Program
	{
		static void Main(string[] args)
		{
			var email = "";
			var password = "";
			var subject = "";
			var message = "";
			var recipient = "";

			Console.WriteLine("Login to your google mail: ");
			Console.Write("Enter E-mail: ");
			email = Console.ReadLine();
			Console.Write("Enter password: ");
			password = Console.ReadLine();
			Console.WriteLine();

			var client = new SmtpClient("smtp.gmail.com", 587)
			{
				Credentials = new NetworkCredential(email, password),
				EnableSsl = true
			};
			Console.WriteLine("Please enter the recipient for the mail: ");
			recipient = Console.ReadLine();

			Console.WriteLine("Please enter the subject for the mail: ");
			subject = Console.ReadLine();

			Console.WriteLine("Please write your mail: ");
			message = Console.ReadLine();

			client.Send(email, recipient, subject, message);

			Console.WriteLine("Sent");
		}
	}
}