using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using VincentTran;
using VincentTran.Facebook;

namespace Server
{
	class mServer
	{
		public static string hostName = Dns.GetHostName();
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1 << 10];                             
			TcpListener server = new TcpListener(IPAddress.Any, 9090);
			server.Start();                                                
			Console.WriteLine("Server is setting.....");

			Stopwatch timer = new Stopwatch();
			timer.Start();                                               

			var client = server.AcceptTcpClient();                        
			var stream = client.GetStream();                               
			var ipe = (IPEndPoint)client.Client.RemoteEndPoint;

			buffer = Encoding.ASCII.GetBytes(hostName+" Accepted !");
			stream.Write(buffer, 0, buffer.Length);                        
			stream.Flush();                                                

			int rec = -1, con = 0;
			while (true)
			{
				int res = 0;
				buffer = new byte[1 << 10];
				rec = stream.Read(buffer, 0, buffer.Length);               
				if (rec == 0)
				{
					Console.WriteLine("Error");
					break;
				}

				string s = Encoding.ASCII.GetString(buffer, 0, rec);          

				string[] temp1 = s.Split('|').Select(str=>str.Trim()).ToArray();
				if (temp1.Length > 1)
				{
					if (temp1[0] == "-array")
					{
						string[] temp2 = temp1[1].Split(' ');
						Console.WriteLine(ipe.Address + " (" + DateTime.Now.ToString("HH:mm:ss") + ") : ");
						Console.WriteLine("Length of array is : " + temp2[0]);
						Console.Write("Array : ");
						for (int i = 1; i < temp2.Length; i++)
						{
							Console.Write(temp2[i] + " ");
							res += int.Parse(temp2[i]);
						}
						Console.WriteLine();
					}
					else
					{
						string[] temp2 = temp1[0].Split(' ');
						if (temp2[0] == "-matrix")
						{
							Console.WriteLine(ipe.Address + " (" + DateTime.Now.ToString("HH:mm:ss") + ") : ");
							Console.WriteLine("Number of row and column is : " + temp2[1] + " " + temp2[2]);
							Console.WriteLine("Matrix : ");
							foreach (var item in temp1[1].Split(','))
							{
								Console.WriteLine(item);
							}
						}
					}
				}
				else
				{
					Console.WriteLine(ipe.Address + " (" + DateTime.Now.ToString("HH:mm:ss") + ") : " + s);
					if (con == 0) { timer.Stop(); Console.WriteLine("Time connect : " + timer.ElapsedMilliseconds / 1000.0 + "s"); con++; }
				}

				if (res == 0) buffer = Encoding.ASCII.GetBytes(hostName+": Received!");
				else buffer = Encoding.ASCII.GetBytes(hostName+": Result = " + res);
				stream.Write(buffer, 0, buffer.Length);                     
				stream.Flush();
			}
			

			Console.ReadKey();
		}
	}
}
