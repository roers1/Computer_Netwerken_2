using System;

namespace Course_2_InLesson_Exercise_2_Non_Blocking_UDP_Client
{
	class Program
	{
		static void Main(string[] args)
		{
			Client client = new Client();
			client.start();
		}
	}
}
