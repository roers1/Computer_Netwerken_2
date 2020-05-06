using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_4_Email_Tool.Models
{
	public class Attachment
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public byte[] ContentBase64 { get; set; }
	}
}
