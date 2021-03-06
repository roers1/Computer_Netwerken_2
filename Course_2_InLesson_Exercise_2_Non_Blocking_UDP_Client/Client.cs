﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Course_2_InLesson_Exercise_2_Non_Blocking_UDP_Client
{
	class Client
	{

		UdpClient udpClientSender = new UdpClient();
		UdpClient udpClientListener = new UdpClient(12345);
		Boolean appRunning = true;

		public void start()
		{
			Thread listenThread = new Thread(Listen);
			listenThread.Start();

			while (appRunning)
			{
				Console.Write("Send over port 54321>");
				String msg = Console.ReadLine();

				if (msg == "stop")
				{
					appRunning = false;
				}

				Byte[] message = Encoding.ASCII.GetBytes(msg);

				IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 54321);

				udpClientSender.Send(message, message.Length, iPEndPoint);
			}

		}

		async void Listen()
		{
			while (appRunning)
			{
				try
				{
					UdpReceiveResult udpReceiveResult = await udpClientListener.ReceiveAsync();
					string receivedData = Encoding.ASCII.GetString(udpReceiveResult.Buffer);

					Console.WriteLine();
					Console.WriteLine($"Data received: {receivedData}");
					Console.Write("Send over port 12345>");

				}
				catch (ObjectDisposedException ex)
				{
					Console.WriteLine(ex.ToString());
				}
				catch (SocketException ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}
	}

}
