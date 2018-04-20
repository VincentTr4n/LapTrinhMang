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
			byte[] buffer = new byte[1 << 10];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			server.Bind(ipe);
			Console.WriteLine("Server is setting....");

			var remote = ipe as EndPoint;
			while (true)
			{
				var rec = server.ReceiveFrom(buffer, ref remote);
				if (rec == 0) break;
				Console.WriteLine("Received : "+ Encoding.ASCII.GetString(buffer,0,rec) +" from : "+remote);
			}

			server.Close();
			Console.ReadLine();
		}
	}
}
