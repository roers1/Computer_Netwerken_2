using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Host
{
	class Server
	{
		private readonly byte[] _bytes = new byte[256];

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
			try
			{
				//Server instantieren
				server = new TcpListener(LocalAddr, Port);

				//Server aanzetten en laten luisteren
				server.Start();

				Console.WriteLine("Waiting for a connection");

				//Accept incoming connection request if one is sended
				TcpClient client = server.AcceptTcpClient();

				//Get a stream object for reading and writing
				NetworkStream stream = client.GetStream();

				Console.WriteLine("Connected!\r\n" +
								  "You can make a move");

				while (!OpponentWon && !Won)
				{
					Turn(stream);

					if (!OpponentWon && !Won)
					{
						EnemyTurn(stream);
					}
					else
					{
						stream.Close();
					}
				}

				Console.Write("Stopping the application...");

				// Shutdown and end connection
				client.Close();
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

		private void EnemyTurn(NetworkStream stream)
		{
			Console.WriteLine("Waiting for opponent to make a turn...");
			var i = stream.Read(_bytes, 0, _bytes.Length);

			var data = Encoding.ASCII.GetString(_bytes, 0, i);
			var move = data.ToCharArray();

			if (move.Length != 2)
			{
				Console.WriteLine("opponent send invalid data, please restart the game...");
			}
			else
			{
				Game.MakeMove((int)char.GetNumericValue(move[0]), (int)char.GetNumericValue(move[1]), Opponent, Player);

				CheckWinner();
				Console.WriteLine(Game);
			}
		}

		private void Turn(NetworkStream stream)
		{
			string moveToSend = null;
			while (true)
			{
				Console.Write("Please give the X coordinate for the move >");
				var input = Console.ReadLine();

				if (InputIsValid(input))
				{
					moveToSend += input;
					break;
				}

				Console.WriteLine("Please give valid coordinates (0,1,2)");
			}

			while (true)
			{
				Console.Write("Please give the Y coordinate for the move >");
				var input = Console.ReadLine();

				if (InputIsValid(input))
				{
					moveToSend += input;
					break;
				}

				Console.WriteLine("Please give valid coordinates (0,1,2)");
			}

			var move = moveToSend.ToCharArray();
			var moveData = Encoding.ASCII.GetBytes(moveToSend);

			Game.MakeMove((int)char.GetNumericValue(move[0]), (int)char.GetNumericValue(move[1]), Player, Opponent);

			stream.Write(moveData, 0, moveData.Length);

			Console.Write(Game);
			CheckWinner();
		}

		private bool InputIsValid(string input)
		{
			return input == "0" || input == "1" || input == "2";
		}

		private void CheckWinner()
		{
			Won = Game.IsWinner(Player);
			OpponentWon = Game.IsWinner(Opponent);
			if (Won)
			{
				Console.WriteLine("CONGRATULATIONS YOU HAVE WON THE GAME");
			}

			if (OpponentWon)
			{
				Console.WriteLine("You lost...");
			}
		}
	}
}