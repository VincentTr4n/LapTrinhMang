using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Instrumentation;
using System.Net;
using System.Collections;

namespace Day1
{
	static class Program
	{
		static void Main(string[] args)
		{
			//Get info use WMI
			Console.WriteLine("---Get info use WMI---");
			ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
			var info = search.Get();
			foreach(var item in info)
			{
				//Number of properties
				Console.WriteLine(item.Properties.Count);

				Console.WriteLine("HostName = " + item["DNSHostName"]);
				Console.WriteLine("Description = " + item["Description"]);

				// IPAddresses
				string[] addresses = (string[])item["IPAddress"];
				foreach (string ipaddress in addresses)
				{
					Console.WriteLine("IPAddress = " + ipaddress);
				}

				// IPSubnets
				string[] subnets = (string[])item["IPSubnet"];
				foreach (string ipsubnet in subnets)
				{
					Console.WriteLine("IPSubnet = " + ipsubnet);
				}

				// DefaultIPGateways
				string[] defaultgateways = (string[])item["DefaultIPGateway"];
				foreach (string defaultipgateway in defaultgateways)
				{
					Console.WriteLine("DefaultIPGateway = " + defaultipgateway);
				}
			}

			Console.WriteLine();
			Console.WriteLine("======================================================");
			Console.WriteLine("---Get info use DNS---");
			//Get info use DNS
			var hostName = Dns.GetHostName();

			//This is host name
			Console.WriteLine("Host name is : " + hostName);

			var hostEntry = Dns.GetHostByName(hostName);
			//Get IpAddress
			foreach (var item in hostEntry.AddressList)
				Console.WriteLine("IpAddress is : " + item.ToString());
			//Get IpAddress is AddFamily
			foreach (var item in hostEntry.AddressList)
				if (item.AddressFamily.ToString() == "InterNetwork")
					Console.WriteLine("AddressFamily is : " + item);

			Console.ReadKey();
		}
	}
}
