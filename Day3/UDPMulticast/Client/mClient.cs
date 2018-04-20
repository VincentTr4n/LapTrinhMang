using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
	class mClient
	{
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1 << 10];
			UdpClient udp = new UdpClient();
			IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("224.100.0.1"), 9090);

			buffer = Encoding.ASCII.GetBytes("Hello World");
			udp.Send(buffer, buffer.Length, ipe);
			while (true)
			{
				string input = Console.ReadLine();
				buffer = Encoding.ASCII.GetBytes(input);
				udp.Send(buffer, buffer.Length, ipe);
			}
			udp.Close();
			Console.ReadKey();
		}
	}
}
