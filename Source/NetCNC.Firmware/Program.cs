using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Microsoft.SPOT.Net.NetworkInformation;

namespace NetCNC.Firmware
{
	public class Program
	{
		public static void Main()
		{
			Thread.Sleep(5000);

			// Output IP addresses for debugging
			foreach (NetworkInterface ip in NetworkInterface.GetAllNetworkInterfaces())
			{
				Debug.Print("IP Address: " + ip.IPAddress + "\n");
			}

			TCPServer server = new TCPServer(23);

			server.Listen();

		}

	}
}
