using System;

namespace Course_2_InLesson_Exercise_1_TCP_Client
{
	class Startup
	{
		static void Main(string[] args)
		{
			Client client = new Client(12345, "127.0.0.1");
			client.Start();
		}
	}
}
