using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerBasic
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1 << 10];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			server.Bind(ipe);
			server.Listen(5);

			var client = server.Accept();
			buffer = Encoding.ASCII.GetBytes("Accepted!!");
			client.Send(buffer, buffer.Length, SocketFlags.None);

			int rec = -1;
			while (true)
			{
				buffer = new byte[1 << 10];
				rec = client.Receive(buffer);
				if (rec == 0) break;

				string s = Encoding.ASCII.GetString(buffer, 0, rec);
				if (s.ToLower() == "d")
				{
					buffer = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
					client.Send(buffer, buffer.Length, SocketFlags.None);
				}else if (s.ToLower() == "t")
				{
					string rep = "Dong Rem, tat den";
					string time = DateTime.Now.ToString("HH:mm:ss").Split(':')[0];
					//int h = int.Parse(time);
					//if (h <= 16 && h >= 9) rep = "Mo rem, bat den";
					buffer = Encoding.ASCII.GetBytes(DateTime.Now.ToString("HH:mm:ss"));
					client.Send(buffer, buffer.Length, SocketFlags.None);
				}else
				{
					buffer = Encoding.ASCII.GetBytes("Sai cu phap");
					client.Send(buffer, buffer.Length, SocketFlags.None);
				}

			}


			Console.ReadKey();

		}
	}
}
