using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Course_2_InLesson_Exercise_1_TCP
{
	class Server
	{
		private int Port { get; set; }
		private IPAddress LocalAddr { get; set; }
		public Server(int port, string localAddr)
		{
			this.Port = port;
			this.LocalAddr = IPAddress.Parse(localAddr);
		}
		public void Start()
		{
			TcpListener server = null;
			try
			{
				//Server instantieren
				server = new TcpListener(LocalAddr, Port);

				//Server aanzetten en laten luisteren
				server.Start();

				Byte[] bytes = new Byte[256];
				String data = null;

				while (true)
				{
					Console.WriteLine("Waiting for a connection");

					//Accept incoming connection request if one is sended
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Connected!");

					data = null;

					//Get a stream object for reading and writing
					NetworkStream stream = client.GetStream();

					int i;

					// Loop to receive all the data sent by the client.
					while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
					{
						// Translate data bytes to a ASCII string.
						data = Encoding.ASCII.GetString(bytes, 0, i);


						Console.WriteLine(data);
					}

					// Shutdown and end connection
					client.Close();
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

			Console.WriteLine("\nHit enter to continue...");
			Console.Read();
		}
	}
}
