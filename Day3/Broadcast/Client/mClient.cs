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
			Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			IPEndPoint ipe1 = new IPEndPoint(IPAddress.Broadcast,9090);
			IPEndPoint ipe2 = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 9090);
			client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

			string hostName = Dns.GetHostName();
			buffer = Encoding.ASCII.GetBytes(hostName);
			client.SendTo(buffer, ipe1);
			client.SendTo(buffer, ipe2);
			while (true)
			{
				break;
			}
			client.Close();
			Console.ReadKey(); 
		}
	}
}
