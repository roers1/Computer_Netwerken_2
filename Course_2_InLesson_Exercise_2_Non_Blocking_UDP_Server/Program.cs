using System;

namespace Course_2_InLesson_Exercise_2_Non_Blocking_UDP_Server
{
	class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server();
			server.Start();
		}
	}
}
