using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VincentTran;

namespace Client
{
	class mClient
	{
		static void Main(string[] args)
		{
			string rec = "", user = Environment.UserName;
			IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, 9090);
			Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				client.Connect(ipe);
			}
			catch { throw new SocketException(); }

			NetworkStream nets = new NetworkStream(client);

			StreamReader reader = new StreamReader(nets);
			StreamWriter writer = new StreamWriter(nets);

			writer.WriteLine("Hello server");
			writer.Flush();

			try
			{
				rec = reader.ReadLine();
			}
			catch { throw new IOException(); }
			Console.WriteLine(rec);

			while (true)
			{
				try
				{
					rec = reader.ReadLine();
				}
				catch { break; }

				Console.WriteLine(">" + rec);
				Console.Write(user+": ");

				string input = Console.ReadLine();
				if (input == "exit") break;

				writer.WriteLine(input);
				writer.Flush();
			}
		}
	}
}
