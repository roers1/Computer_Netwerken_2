using System;
using System.Collections.Generic;
using System.Text;

namespace Course_4_LDAP_Tool
{
	class Tool
	{
		LDAP ldapClient = new LDAP();

		public void Start()
		{
			bool stop = false;

			while (!stop)
			{
				Console.WriteLine("Welcome to the LDAP Tool");
				Console.WriteLine($"Currently connected to: {ldapClient.LDAP_PATH}");
				Console.WriteLine("1) Configure directory");
				Console.WriteLine("2) Lookup a person");
				Console.WriteLine("3) Close application");

				Console.Write("Please select an action you would like to perform> ");
				string command = Console.ReadLine();

				switch (int.Parse(command ?? string.Empty))
				{
					case 1:
						ConfigureDirectory();
						break;
					case 2:
						LookupPerson();
						break;
					case 3:
						stop = true;
						break;
					default:
						Console.WriteLine("invalid command");
						break;
				}
			}
		}

		private void ConfigureDirectory()
		{
			Console.WriteLine("\r\n Please enter the new directory you would like to use >");

			ldapClient.LDAP_PATH = Console.ReadLine();

			Console.WriteLine("Directory path changed!");
		}

		private void LookupPerson()
		{
			ldapClient.search();
		}
	}
}