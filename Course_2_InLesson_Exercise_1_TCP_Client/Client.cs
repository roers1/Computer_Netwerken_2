using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Course_2_InLesson_Exercise_1_TCP_Client
{
    class Client
    {
        public int Port { get; set; }
        public string LocalAddr { get; set; }
        public Client(int port, string localAddr)
        {
            this.Port = port;
            this.LocalAddr = localAddr;
        }
        public void Start()
        {
            while (true)
            {
                Console.Write("Type your message: ");
                string message = Console.ReadLine();

                Connect(LocalAddr, message);

                if (message == "end")
                {
                    break;
                }

            }

            static void Connect(string server, string message)
            {
                try
                {

                    int port = 12345;
                    TcpClient client = new TcpClient(server, port);

                    // Translate the passed message into ASCII and store it as a Byte array.
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                    NetworkStream stream = client.GetStream();

                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);

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
        }
    }
}
