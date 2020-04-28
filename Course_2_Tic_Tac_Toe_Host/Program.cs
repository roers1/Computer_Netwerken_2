using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Course_2_Tic_Tac_Toe_Host
{
	class Program
	{
		private static void Main(string[] args)
		{
			IPAddress ipAddress = null;

			Console.Write("Welcome to TicTacToe!\r\n" +
			              "To start the game please enter the ip you would like to host you game on >");
			while (ipAddress == null)
			{
				try
				{
					ipAddress = IPAddress.Parse(Console.ReadLine() ?? string.Empty);
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
			              "Now please enter the port which the other player has to connect to >");
			var port = int.Parse(Console.ReadLine() ?? "420");

			if (port == 420)
			{
				Console.WriteLine("Using default port 420.");
			}
			else
			{
				Console.WriteLine($"Using port {port}.");
			}

			Console.Write("Press enter to start hosting and wait for a opponent...");
			Console.ReadLine();

			Server server = new Server(port, ipAddress,"X");
			server.Start();
		}
	}
}