using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Course_4_Email_Tool.Models
{
	public class Mail
	{
		public string From { get; set; }
		public string To { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public IList<AttachmentCustom> AttachmentsList;
		public DateTimeOffset SendDate { get; set; }
		public string MessageId { get; set; }

		public Mail()
		{
			AttachmentsList = new List<AttachmentCustom>();
		}
	}
}