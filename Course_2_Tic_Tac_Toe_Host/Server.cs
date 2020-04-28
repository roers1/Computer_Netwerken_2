using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Host
{
	class Server
	{
		private int Port { get; set; }
		private IPAddress LocalAddr { get; set; }
		private TicTacToe Game { get; }
		public string Player { get; set; }
		public string Opponent { get; set; }
		public bool Won { get; set; }
		public bool OpponentWon { get; set; }
		public Server(int port, IPAddress localAddr, string player)
		{
			this.Port = port;
			this.LocalAddr = localAddr;
			this.Game = new TicTacToe();
			this.Player = player;

			if (player == "X")
			{
				Opponent = "O";
			}
			else
			{
				Opponent = "X";
			}

			this.Won = false;
			this.OpponentWon = false;
		}
		public void Start()
		{
			TcpListener server = null;
			Console.WriteLine(Game);
			try
			{
				//Server instantieren
				server = new TcpListener(LocalAddr, Port);

				//Server aanzetten en laten luisteren
				server.Start();

				var bytes = new byte[256];

				while (true)
				{
					Console.WriteLine("Waiting for a connection");

					//Accept incoming connection request if one is sended
					TcpClient client = server.AcceptTcpClient();
					
					//Get a stream object for reading and writing
					NetworkStream stream = client.GetStream();

					Console.WriteLine("Connected!\r\n" +
					                  "You can make a move");
					Console.WriteLine(Game);

					string moveToSend = null;

					Console.Write("Please give the X coordinate for the move >");
					moveToSend += Console.ReadLine();

					Console.Write("Please give the Y coordinate for the move >");
					moveToSend += Console.ReadLine();

					var moveData = Encoding.ASCII.GetBytes(moveToSend);

					stream.Write(moveData, 0, moveData.Length);
					moveToSend = null;

					while (true)
					{
						// Loop to receive all the data sent by the client.
						int i;
						while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
						{
							// Translate data bytes to a ASCII string.
							var data = Encoding.ASCII.GetString(bytes, 0, i);
							string[] move = {data};

							Game.makeMove(int.Parse(move[0]), int.Parse(move[1]), Player, Opponent);
							Won = Game.IsWinner(Player);
							OpponentWon = Game.IsWinner(Opponent);
							Console.WriteLine(Game);
						}

						if (Won)
						{
							Console.WriteLine("CONGRATULATIONS YOU HAVE WON THE GAME");
							break;
						}

						if(OpponentWon)
						{
							Console.WriteLine("You lost...");
							break;
						}

						Console.Write("Please give the X coordinate for the move >");
						moveToSend += Console.ReadLine();

						Console.Write("Please give the Y coordinate for the move >");
						moveToSend += Console.ReadLine();

						moveData = Encoding.ASCII.GetBytes(moveToSend);

						stream.Write(moveData, 0, moveData.Length);
						moveToSend = null;

					}
					Console.Write("Stopping the application...");

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
	}
}