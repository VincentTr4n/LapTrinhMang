using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Day2
{
	class Program
	{
		static void Main(string[] args)
		{
			IPAddress ip1 = IPAddress.Loopback;
			IPAddress ip3 = IPAddress.Broadcast;
			IPAddress ip4 = IPAddress.Any;
			IPAddress ip5 = IPAddress.None;
			Console.Write(ip1 + "|\n"  + "|\n" + ip3 + "|\n" + ip4 + "|\n" + ip5 + "|\n");

			var hostName = Dns.GetHostName();
			Console.WriteLine("Host name is : " + hostName);

			var hostEntry = Dns.GetHostByName(hostName);
			//Console.WriteLine(hostEntry.AddressList[0]);
			//if (ip2.Equals(hostEntry.AddressList[0])) Console.WriteLine("OK");
			//foreach (var item in hostEntry.AddressList)
			//	Console.WriteLine(item+"|");

			IPEndPoint ep = new IPEndPoint(hostEntry.AddressList[0], 9023);
			//Console.WriteLine(ep.ToString());
			//Console.WriteLine("Dia chia ip la "+ep.Address+" | Port ban dau la :" + ep.Port);
			//Console.WriteLine("Address family la : " + ep.AddressFamily);

			//ep.Port = 2355;
			//Console.WriteLine("Port sau do la : " + ep.Port);

			//Console.WriteLine("Gia tri max la : "+IPEndPoint.MaxPort);
			//Console.WriteLine("Gia tri min la : " + IPEndPoint.MinPort);

			//var sd = ep.Serialize();
			//Console.WriteLine(sd);


			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(ep);
			IPEndPoint local = (IPEndPoint)socket.LocalEndPoint;

			Console.WriteLine(local);
			//Console.WriteLine("IPendpoint la : " + socket.LocalEndPoint);

			//Console.WriteLine("Address family la : " + socket.AddressFamily + "\n" + "socket type la : " + socket.SocketType + "\n" + "Protocel la : " + socket.ProtocolType);
			Console.ReadKey();
		}
	}
}
