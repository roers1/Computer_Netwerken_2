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

					//Tcp client accepteren als er een aanvraag naar de 'webpagina' wordt gedaan
					TcpClient client = server.AcceptTcpClient();

					//Stream object verkrijgen om te kunnen lezen en schrijven naar de client
					var stream = client.GetStream();

					using (var sr = new StreamReader(stream))
					{
						var noInformation = false;
						//Zolang er informatie komt vanuit de client blijft het ingelezen worden
						while (!sr.EndOfStream && !noInformation)
						{
							
							var i = sr.ReadLine();

							if (string.IsNullOrEmpty(i)) noInformation = true;

							//De GET en Filename los maken van elkaar
							var dataSplit = i?.Split(" ");

							//Als er een GET method gegeven wordt dan hebben we alle informatie die benodigd is en kunnen we verder.
							if (dataSplit[0].StartsWith("GET"))
							{
								//Filename uit de array halen
								Filename = dataSplit[1].Remove(0, 1);
								noInformation = true;
							}
						}

						//Als de filename leeg is dan is het request niet geldig omdat we niks hebben om mee te werken
						if (string.IsNullOrEmpty(Filename))
						{
							//Error response schrijven volgens protocol regels
							var error = "HTTP/1.1 400 Bad request";
							SendMessage(error, stream);
						}
						else
						{
							//Als het bestand bestaat kan hij uitgelezen worden
							if (File.Exists(Filename))
							{
								//File uitlezen
								var dataToSend = File.ReadAllLines(Filename);

								//Response schrijven volgens protocol regels
								var responseHeader = "HTTP/1.1 200 OK";

								//Header verzenden
								SendMessage(responseHeader, stream);

								//body verzenden met de gegevens die gevraagd zijn
								foreach (var x in dataToSend)
								{
									SendMessage(x, stream);
								}
							}
							else
							{
								//bestand is niet gevonden en er wordt een 404 terug gegeven
								var error = "HTTP/1.1 404 Not found";
								SendMessage(error, stream);
							}
						}
					}

					//Als de gegevens verstuurd zijn stoppen we de verbinding
					client.Close();
				}
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
			finally
			{
				//Stoppen indien nodig
				server?.Stop();
			}
		}

		private void SendMessage(string msg, Stream stream)
		{
			//bytes array aanmaken om de gegevens te verzenden
			var response = Encoding.UTF8.GetBytes($"{msg}{Environment.NewLine}");

			//meegekregen stream gebruiken om de gegevens te versturen
			stream.Write(response, 0, response.Length);
		}
	}
}