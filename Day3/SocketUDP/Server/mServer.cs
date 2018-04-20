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
			byte[] buffer = new byte[1024];
			IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9090);
			Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			server.Bind(ipe);

			IPEndPoint ipeRemote = new IPEndPoint(IPAddress.Loopback, 9090);
			var remote = ipeRemote as EndPoint;

			int rec = server.ReceiveFrom(buffer, ref remote);
			Console.WriteLine("Connected from "+ipeRemote.Address);
			Console.WriteLine(Encoding.ASCII.GetString(buffer,0,rec));

			buffer = Encoding.ASCII.GetBytes("Accepted!");
			server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);

			int m = 1000;

			while (true)
			{
				buffer = new byte[1024];
				rec = server.ReceiveFrom(buffer, ref remote);
				if (rec == 0) break;

				string s = Encoding.ASCII.GetString(buffer, 0, rec);
				Console.WriteLine(ipeRemote.Address + "(" + DateTime.Now.ToString("HH:mm:ss") + ") :" + s);

				var temp = s.Split(' ');
				if(temp[0]!="LOTO")
				{
					if (temp[0] == "nap")
					{
						m += int.Parse(temp[1]);
						buffer = Encoding.ASCII.GetBytes("Da nap "+temp[1]+" va tong tien ban co : "+m);
						server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
					}
					else
					{
						buffer = Encoding.ASCII.GetBytes("Sai roi");
						server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
					}
				}else
				{
					int n = int.Parse(temp[1]);
					if(n<=0)
					{
						buffer = Encoding.ASCII.GetBytes("Khong co gi");
						server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
					}
					else
					{
						if (n <= m)
						{
							Random rnd = new Random();
							string res = "";
							for (int i = 0; i < n; i++)
							{
								res += rnd.Next(1, 100).ToString() + " ";
							}
							buffer = Encoding.ASCII.GetBytes(res);
							server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
							m -= n;
						}
						else
						{
							buffer = Encoding.ASCII.GetBytes("Khong du tien vi chi con " + m);
							server.SendTo(buffer, buffer.Length, SocketFlags.None, remote);
						}
					}
				}
			}

			//for (int i = 0; i < 9; i++)
			//{
			//	buffer = new byte[1 << 10];
			//	rec = server.ReceiveFrom(buffer, ref remote);
			//	if (rec == 0) break;

			//	Console.WriteLine(ipeRemote.Address + "(" + DateTime.Now.ToString("HH:mm:ss") + ") :" + Encoding.ASCII.GetString(buffer, 0, rec));
			//}

			server.Close();
			Console.ReadKey();

			// id1, id2, id3 va tai khoan  = 0; gap cu' phap nap tien => id.tk = td+m;
			// LOTO: 
		}
	}
}
