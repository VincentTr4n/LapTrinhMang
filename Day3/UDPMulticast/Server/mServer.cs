using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
	class mServer
	{
		static void Main(string[] args)
		{
			UdpClient udp = new UdpClient(9090);
			Console.WriteLine("Server is setting ....");
			udp.JoinMulticastGroup(IPAddress.Parse("224.100.0.1"), 50);

			IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 9090);

			while (true)
			{
				var buffer = udp.Receive(ref ipe);
				var data = Encoding.ASCII.GetString(buffer);
				Console.WriteLine("Received : " + data + " from : " + ipe.Address);
			}

			udp.Close();

			Console.ReadKey();
		}
	}
}
