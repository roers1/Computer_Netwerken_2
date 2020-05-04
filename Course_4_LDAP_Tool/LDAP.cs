using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.DirectoryServices;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace Course_4_LDAP_Tool
{
	class LDAP
	{
		public string LDAP_PATH { get; set; }
		public string OU { get; set; }

		public LDAP()
		{
			LDAP_PATH = "LDAP://ldap.itd.umich.edu";
			OU = "Medical School - Faculty and Staff";
		}

		public void search()
		{
			var entry = new DirectoryEntry
			{
				Path = LDAP_PATH,
				AuthenticationType = AuthenticationTypes.Anonymous
			};

			Console.WriteLine("Please enter the name you would like to search: ");
			var name = Console.ReadLine();

			//cn = common name
			var search = new DirectorySearcher(entry)
			{
				Filter = $"(&(cn={name})(ou=Medical School - Faculty and Staff)(mail=*))",
				SearchScope = SearchScope.Subtree
			};

			var counter = 0;
			var person = search.FindAll();
			IList<Person> persons = new List<Person>();

			foreach (SearchResult searchResult in person)
			{
				var newPerson = new Person();
				counter++;

				foreach (var displayname in searchResult.Properties["displayname"])
				{
					newPerson.Name = (string) displayname;
					Console.WriteLine(displayname + "\r\n");
				}

				foreach (var propertiesPropertyName in searchResult.Properties.PropertyNames)
				{
					foreach (var propertie in searchResult.Properties[(string) propertiesPropertyName])
					{
						if ((string) propertiesPropertyName == "mail")
						{
							newPerson.Email = (string) propertie;
						}

						Console.WriteLine(propertiesPropertyName + ": " + propertie);
					}
				}

				persons.Add(newPerson);

				Console.WriteLine("--------------------\r\n");
			}

			if (counter == 0)
			{
				Console.WriteLine("No person was found...\r\n");
			}
			else
			{
				Export(persons);
			}
		}

		private void Export(IList<Person> persons)
		{
			bool valid = true;
			while (valid)
			{
				Console.WriteLine("Would you like to export the results to a file? (y/n)");
				var command = Console.ReadLine();

				switch (command)
				{
					case "y":
						PrintPersons(persons);
						valid = false;
						break;
					case "n":
						valid = false;
						break;
					default:
						Console.WriteLine("Please answer with \"y\" or \"n\" >");
						break;
				}
			}
		}

		private void PrintPersons(IList<Person> persons)
		{
			var lines = persons.Select(x => x.ToString()).ToArray();
			System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
			Console.WriteLine("Exported to C:\\Users\\Public\\TestFolder\\WriteLines.txt\r\n");
		}
	}
}