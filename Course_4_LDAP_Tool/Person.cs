using System;
using System.Collections.Generic;
using System.Text;

namespace Course_4_LDAP_Tool
{
	class Person
	{
		public string Name { get; set; }
		public string Email { get; set; }

		public override string ToString()
		{
			return $"{Name}: {Email}";
		}
	}
}
