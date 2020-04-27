using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Course_1_TCPView
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpListener server = null;
			try
			{
				//Listener op poort 12345 zetten
				int port = 12345;
				IPAddress localAddr = IPAddress.Parse("127.0.0.1");

				//Server instantieren
				server = new TcpListener(localAddr, port);

				while (true)
				{
					//Server aanzetten en laten luisteren
					server.Start();
				}


			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
			finally
			{
				// Stop listening for new clients.
				server.Stop();
			}

		}
	}
}
