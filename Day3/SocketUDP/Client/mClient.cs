using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using VincentTran.IO;

namespace Client
{
	class mClient
	{
		
		static void Main(string[] args)
		{
			int n = 1024;
			byte[] buffer = new byte[n];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 9090);
			Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			//client.Connect(ipe);

			var remote = ipe as EndPoint ;

			buffer = Encoding.ASCII.GetBytes("Connected!");
			//client.Send(buffer, buffer.Length, SocketFlags.None);
			client.SendTo(buffer, buffer.Length, SocketFlags.None, ipe);

			int m = 10;

			int rec = -1;
			while (true)
			{
				buffer = new byte[n];
				string s = "";
				try
				{
					rec = client.Receive(buffer);
					s = Encoding.ASCII.GetString(buffer, 0, rec);
					//rec = client.ReceiveFrom(buffer, ref remote);
					Console.WriteLine(s);
				}
				catch { Console.WriteLine("Connect failed, try again! (enter: connect)"); }

				Console.Write("Me :");
				string input = Console.ReadLine();
				//if (input.Length > n) n *= 2;
				//buffer = new byte[n];
				buffer = Encoding.ASCII.GetBytes(input);
				//client.Send(buffer, buffer.Length, SocketFlags.None);
				client.SendTo(buffer, buffer.Length, SocketFlags.None, ipe);


			}
			//for (int i = 0; i < 10; i++)
			//{
			//	buffer = new byte[1 << 10];
			//	buffer = Encoding.ASCII.GetBytes(i.ToString()+"absadsa");
			//	client.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
			//}

			client.Close();
			Console.ReadKey();
		}
	}
}
