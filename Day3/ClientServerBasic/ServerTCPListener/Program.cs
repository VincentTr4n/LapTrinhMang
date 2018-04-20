using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerTCPListener
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1 << 10];
			TcpListener server = new TcpListener(IPAddress.Any, 9090);
			server.Start();

			var client = server.AcceptSocket();
			int rec = client.Receive(buffer);
			if (rec == 0) Console.WriteLine("Not Data");
			else
			{
				Console.WriteLine(Encoding.ASCII.GetString(buffer,0,rec));

				buffer = Encoding.ASCII.GetBytes("OK");
				client.Send(buffer, 0, buffer.Length, SocketFlags.None);
			}
			Console.ReadKey();
		}
	}
}
