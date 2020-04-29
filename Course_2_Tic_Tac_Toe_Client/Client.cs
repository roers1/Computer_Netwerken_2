﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Client
{
	class Client
	{
		private int Port { get; set; }
		private string Server { get; set; }
		private TicTacToe Game { get; }
		public string Player { get; set; }
		public string Opponent { get; set; }
		public bool Won { get; set; }
		public bool OpponentWon { get; set; }

		private readonly byte[] _bytes = new byte[256];

		public Client(int port, string server, string player)
		{
			this.Port = port;
			this.Server = server;
			this.Game = new TicTacToe();
			this.Player = player;

			Opponent = player == "X" ? "O" : "X";

			this.Won = false;
			this.OpponentWon = false;
		}

		public void Start()
		{
			try
			{
				TcpClient client = new TcpClient(Server, Port);

				NetworkStream stream = client.GetStream();

				Console.WriteLine("Connected!\r\n");
				Console.WriteLine(Game);

				while (!OpponentWon && !Won)
				{
					EnemyTurn(stream);

					if (!OpponentWon)
					{
						Turn(stream);
					}
				}

				// Close everything.
				stream.Close();
				client.Close();
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
		}

		private void EnemyTurn(NetworkStream stream)
		{
			Console.WriteLine("Waiting for opponent to make a turn...");
			int i;
			while ((i = stream.Read(_bytes, 0, _bytes.Length)) != 0)
			{
				var data = Encoding.ASCII.GetString(_bytes, 0, i);
				var move = data.ToCharArray();

				Game.MakeMove((int)char.GetNumericValue(move[0]), (int)char.GetNumericValue(move[1]), Opponent, Player);

				CheckWinner();
				Console.WriteLine(Game);
			}

			CheckWinner();
		}

		private void Turn(NetworkStream stream)
		{
			string moveToSend = null;
			Console.Write("Please give the X coordinate for the move >");
			moveToSend += Console.ReadLine();

			Console.Write("Please give the Y coordinate for the move >");
			moveToSend += Console.ReadLine();
			var move = moveToSend.ToCharArray();
			var moveData = Encoding.ASCII.GetBytes(moveToSend);

			Game.MakeMove((int)char.GetNumericValue(move[0]), (int)char.GetNumericValue(move[1]), Player, Opponent);

			stream.Write(moveData, 0, moveData.Length);

			CheckWinner();
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