using System;
using System.DirectoryServices;

namespace Course_4_InLesson_Exercise_1_LDAP
{
	class Program
	{
		static void Main(string[] args)
		{
			const string LDAP_PATH = "LDAP://ldap.itd.umich.edu";
			const string USERNAME = "Amy Newman";

			using (var entry = new DirectoryEntry())
			{
				entry.Path = LDAP_PATH;
				entry.AuthenticationType = AuthenticationTypes.Anonymous;

				//cn = common name
				var search = new DirectorySearcher(entry) {Filter = $"(cn={USERNAME})"};
				search.SearchScope = SearchScope.Subtree;

				//ou = organizational unit
				//search.PropertiesToLoad.Add("ou");

				var person = search.FindAll();

				foreach (SearchResult searchResult in person)
				{
					foreach (var displayname in searchResult.Properties["displayname"])
					{
						Console.WriteLine(displayname + "\r\n");
					}

					foreach (var propertiesPropertyName in searchResult.Properties.PropertyNames)
					{
						foreach (var propertie in searchResult.Properties[(string) propertiesPropertyName])
						{
							Console.WriteLine(propertiesPropertyName + ": " + propertie);
						}
					}

					Console.WriteLine("--------------------\r\n");
				}
			}
		}
	}
}