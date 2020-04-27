using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Course_2_InLesson_Exercise_1_TCP_Server
{
	class Startup
	{
		static void Main(string[] args)
		{
			Server server = new Server(12345, "127.0.0.1");
			server.Start();
		}

	}
}
