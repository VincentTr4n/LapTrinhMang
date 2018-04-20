using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1 << 10];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 9090);
			Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			client.Connect(ipe);

			int rec = -1;
			while (true)
			{
				buffer = new byte[1 << 10];
				rec = client.Receive(buffer);
				if (rec == 0) break;

				string s = Encoding.ASCII.GetString(buffer, 0, rec);
				Console.WriteLine(s);

				string input = Console.ReadLine();
				buffer = Encoding.ASCII.GetBytes(input);
				client.Send(buffer, buffer.Length, SocketFlags.None);
			}
			Console.ReadKey();
		}
	}
}
