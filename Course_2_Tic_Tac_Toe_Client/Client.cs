using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Course_2_Tic_Tac_Toe_Client
{
    class Client
    {
        public int Port { get; set; }
        public String LocalAddr { get; set; }
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
                String message = Console.ReadLine();

                Connect(LocalAddr, message);

                if (message == "end")
                {
                    break;
                }

            }

            static void Connect(String server, String message)
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
