using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Microsoft.VisualBasic;

namespace Course_4_LDAP_Tool
{
	class LDAP
	{
		public string LDAP_PATH { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string OU { get; set; }

		public DirectoryEntry DirectoryEntry = new DirectoryEntry();


		public LDAP()
		{
			LDAP_PATH = "LDAP://ldap.itd.umich.ed";
			OU = "Medical School - Faculty and Staff";
		}

		public void Connect()
		{
			DirectoryEntry.Path = LDAP_PATH;
			DirectoryEntry.AuthenticationType = AuthenticationTypes.Anonymous;
		}
	}
}
