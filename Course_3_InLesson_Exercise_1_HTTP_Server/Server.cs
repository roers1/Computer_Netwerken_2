using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Course_3_InLesson_Exercise_1_HTTP_Server
{
	public class Server
	{
		private int Port { get; set; }
		private IPAddress LocalAddr { get; set; }
		public string Filename { get; set; }

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

				byte[] bytes = new byte[256];

				while (true)
				{
					Console.WriteLine("Waiting for a connection");

					//Accept incoming connection request if one is sended
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Connected!");

					//Get a stream object for reading and writing
					var stream = client.GetStream();


					using (var sr = new StreamReader(stream))
					{
						var noInformation = false;
						while (!sr.EndOfStream && !noInformation)
						{
							// Loop to receive all the data sent by the client.
							var i = sr.ReadLine();
							if (string.IsNullOrEmpty(i)) noInformation = true;
							var dataSplit = i?.Split(" ");

							if (dataSplit[0].StartsWith("GET"))
							{
								Filename = dataSplit[1].Remove(0, 1);
								noInformation = true;
							}
						}

						if (string.IsNullOrEmpty(Filename))
						{
							Console.WriteLine("NULL OF LEEG");
							var error = "HTTP/1.1 400 Bad request";
							SendMessage(error, stream);
						}
						else
						{
							if (File.Exists(Filename))
							{
								Console.WriteLine("FILE BESTAAT");
								var dataToSend = File.ReadAllLines(Filename);
								Console.WriteLine(dataToSend);
								var responseHeader = "HTTP/1.1 200 OK";
								SendMessage(responseHeader, stream);

								foreach (var x in dataToSend)
								{
									SendMessage(x, stream);
								}
							}
							else
							{
								Console.WriteLine("FILE BESTAAT NIET");
								var error = "HTTP/1.1 404 Not found";
								SendMessage(error, stream);
							}
						}
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
				server?.Stop();
			}

			Console.WriteLine("\nHit enter to continue...");
			Console.Read();
		}

		private void SendMessage(string msg, Stream stream)
		{
			var response = Encoding.UTF8.GetBytes($"{msg}{Environment.NewLine}");
			stream.Write(response, 0, response.Length);
		}
	}
}