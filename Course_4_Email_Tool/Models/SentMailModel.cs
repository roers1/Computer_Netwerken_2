using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Course_4_Email_Tool.Models
{
	public class SentMailModel
	{
		public string To { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		//public File File { get; set; }
	}
}
