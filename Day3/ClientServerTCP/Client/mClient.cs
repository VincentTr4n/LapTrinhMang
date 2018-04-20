using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using VincentTran.IO;

namespace Client
{
	class mClient
	{
		public enum TypeOfInput {Arr,Matrix};
		public static byte[] GetInput(TypeOfInput type,string input)
		{
			IOProcess inp = new IOProcess();
			byte[] res = new byte[1 << 10];
			if (type == TypeOfInput.Arr)
			{
				string t = input;
				int n = inp.NextInt();
				string a = inp.NextLine();
				res = Encoding.ASCII.GetBytes(t + "|"+n+" " + a);
			}
			else if (type == TypeOfInput.Matrix)
			{
				string t = input;
				int n = inp.NextInt();
				int m = inp.NextInt();
				StringBuilder builder = new StringBuilder();
				builder.Append(t + " " + n + " " + m + "|");
				//builder.Append(inp.NextLine());
				for (int i = 0; i < n; i++) builder.Append(inp.NextLine()+ ",");
				res = Encoding.ASCII.GetBytes(builder.ToString());
			}
			inp.Dispose();
			return res;
		}
		static void Main(string[] args)
		{
			byte[] buffer = new byte[1<<10];
			TcpClient client = new TcpClient(Dns.GetHostName(), 9090);
			var stream = client.GetStream();

			int rec = stream.Read(buffer, 0, 1<<10);
			Console.WriteLine(Encoding.ASCII.GetString(buffer,0,rec));

			buffer = Encoding.ASCII.GetBytes("Connected !");
			stream.Write(buffer, 0, buffer.Length);
			stream.Flush();

			while (true)
			{
				buffer = new byte[1 << 10];
				rec = stream.Read(buffer, 0, buffer.Length);
				if (rec == 0)
				{
					Console.WriteLine("Error");
					break;
				}

				string s = Encoding.ASCII.GetString(buffer, 0, rec);
				Console.WriteLine(">" + s);

				Console.Write(Environment.UserName + " : ");
				string input = Console.ReadLine();

				if (input == "-array") buffer = GetInput(TypeOfInput.Arr, input);
				else if (input == "-matrix") buffer = GetInput(TypeOfInput.Matrix, input);
				else buffer = Encoding.ASCII.GetBytes(input);

				stream.Write(buffer, 0, buffer.Length);
				stream.Flush();
			}

			Console.ReadKey();
		}
	}
}
