using System;

namespace Course_3_InLesson_Exercise_1_HTTP_Server
{
	class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server(12345, "127.0.0.1");
			server.Start();
		}
	}
}
