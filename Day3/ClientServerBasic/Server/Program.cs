using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] data = new byte[1024];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipe);
			server.Listen(5);

			Console.WriteLine("Server is setting...");

			Socket client = server.Accept();
			//NetworkStream stream = new NetworkStream(client);

			var rep1 = Encoding.ASCII.GetBytes("Accepted!");
			client.Send(rep1, rep1.Length, SocketFlags.None);

			while (true)
			{
				var rec = client.Receive(data);
				if (rec == 0)
				{
					Console.WriteLine("Error!");
					break;
				}
				else
				{
					var dataReceive = Encoding.ASCII.GetString(data, 0, rec);
					Console.WriteLine("Client : " + dataReceive);
					string[] temp = dataReceive.Split(' ');

					//Console.WriteLine(temp[0]+"|"+temp[2]);

					float a = float.Parse(temp[1]);
					float b = float.Parse(temp[2]);

					if (temp[0] == "sum")
					{
						var rep = Encoding.ASCII.GetBytes("sum :" + (a + b).ToString());
						client.Send(rep, rep.Length, SocketFlags.None);
					}
					else if (temp[0] == "sub")
					{
						var rep = Encoding.ASCII.GetBytes("sub : " + (a - b).ToString());
						client.Send(rep, rep.Length, SocketFlags.None);
					}
					if (temp[0] == "mul")
					{
						var rep = Encoding.ASCII.GetBytes("mul : " + (a * b).ToString());
						client.Send(rep, rep.Length, SocketFlags.None);
					}
					if (temp[0] == "div")
					{
						var rep = Encoding.ASCII.GetBytes("div : " + (a/b).ToString());
						client.Send(rep, rep.Length, SocketFlags.None);
					}
				}

			}
			server.Close();
			Console.ReadKey();
		}
	}
}
