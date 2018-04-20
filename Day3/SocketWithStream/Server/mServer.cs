using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using VincentTran;

namespace Server
{
	class mServer
	{
		static void Main(string[] args)
		{
			string hostName = Dns.GetHostName();
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipe);
			server.Listen(10);

			var client = server.Accept();
			var ipec = client.RemoteEndPoint as IPEndPoint;
			Console.WriteLine("Connectd from : "+ ipec.Address + " - port : "+ipec.Port);

			NetworkStream nets = new NetworkStream(client);

			StreamReader reader = new StreamReader(nets);
			StreamWriter writer = new StreamWriter(nets);

			writer.WriteLine("Accepted!");
			writer.Flush();

			string rec = "";
			while (true)
			{
				try
				{
					rec = reader.ReadLine();
				}
				catch { break; }

				Console.WriteLine(ipec.Address+"("+DateTime.Now.ToString("HH:mm:ss")+") : "+rec);

				try
				{
					writer.WriteLine(hostName + " : Received! and Sum : " + rec.ToIntArray().Sum());
					writer.Flush();
				}
				catch
				{
					writer.WriteLine(hostName + " : Received!");
					writer.Flush();
				}
			}


			Console.ReadKey();
		}
	}
}
