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
			byte[] data = new byte[1024];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipe);
			server.Listen(5);

			Console.WriteLine("Server is setting...");

			Socket client = server.Accept();

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

					if (dataReceive.ToLower() == "d")
					{
						string s = DateTime.Now.ToString("dd-MM-yyyy");
						var rep = Encoding.ASCII.GetBytes(s);
						client.Send(rep, rep.Length, SocketFlags.None);
					}else if (dataReceive.ToLower() == "t")
					{
						string s = "Dong rem, Tat den";
						string h = DateTime.Now.ToString("HH:mm:ss").Split(':')[0];
						Console.WriteLine(h);
						int H = int.Parse(h);
						if (H <= 16 && H >= 9) s = "Mo Rem, bat den";
						var rep = Encoding.ASCII.GetBytes(s);
						client.Send(rep, rep.Length, SocketFlags.None);

					}else
					{
						var rep = Encoding.ASCII.GetBytes("no");
						client.Send(rep, rep.Length, SocketFlags.None);
					}
				}

			}
			server.Close();
			Console.ReadKey();

		}
	}
}
