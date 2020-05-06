using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_4_Email_Tool.Models
{
	public class LoginModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string IMAP_HOST { get; set; }
		public int OUTGOING_PORT_SMTP { get; set; } = 587;
		public int INCOMING_PORT_IMAP { get; set; } = 993;
	}
}
