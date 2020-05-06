using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_4_Email_Tool.Models
{
	public class Inbox
	{
		public IList<Mail> Mails { get; set; }
		public int MailsToShowAmount { get; set; } = 10;
	}
}
