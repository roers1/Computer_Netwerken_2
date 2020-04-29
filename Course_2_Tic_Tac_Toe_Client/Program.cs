using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Course_2_Tic_Tac_Toe_Client
{
	class Program
	{
		private static void Main(string[] args)
		{
			string ipAddress = null;
			TicTacToe game = new TicTacToe();

			Console.Write("Welcome to TicTacToe!\r\n" +
			              "To start the game please enter the ip you would like to connect to >");

			while (ipAddress == null)
			{
				try
				{
					ipAddress = Console.ReadLine() ?? string.Empty;
				}
				catch (IOException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (OutOfMemoryException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (ArgumentOutOfRangeException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (SocketException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (FormatException e)
				{
					Console.WriteLine(e.Message);
				}

				finally
				{
					if (ipAddress == null) Console.Write("\r\nIp was not valid, please enter a valid IP Address >");
				}
			}

			Console.Write($"\r\nGame will be run on IP: {ipAddress} \r\n" +
			              "Now please enter the port which you would like to connect to >");
			var port = int.Parse(Console.ReadLine() ?? "420");

			Console.WriteLine(port == 420 ? "Using default port 420." : $"Using port {port}.");

			Console.Write("Press enter to to try connect with the host...");
			Console.ReadLine();

			Client client = new Client(port, ipAddress, "O");
			client.Start();
		}
	}
}
