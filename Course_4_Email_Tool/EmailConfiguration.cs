using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_4_Email_Tool
{
	public class EmailConfiguration
	{
		public string SmtpServer { get; set; }
		public int SmtpPort { get; set; }
		public string SmtpUsername { get; set; }
		public string SmtpPassword { get; set; }

		public string DisplayName { get; set; }

		public string ImapServer { get; set; }
		public int ImapPort { get; set; }
		public string ImapUsername { get; set; }
		public string ImapPassword { get; set; }
	}
}
