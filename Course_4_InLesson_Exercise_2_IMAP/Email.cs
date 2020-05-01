using System;
using System.Collections.Generic;
using System.Text;

namespace Course_4_InLesson_Exercise_IMAP_SMTP
{
	class Email
	{
		public string From { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool HasAttachment { get; set; }
	}
}
