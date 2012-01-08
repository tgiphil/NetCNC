using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

using NetCNC.Devices;

namespace NetCNC.Firmware
{
	internal class TCPServer : IDisposable
	{
		private IDigitalOutputPort led0 = new CPUOutputPort(Pins.GPIO_PIN_D0, false);
		private IDigitalOutputPort led1 = new CPUOutputPort(Pins.GPIO_PIN_D1, false);
		private IDigitalOutputPort led2 = new CPUOutputPort(Pins.GPIO_PIN_D2, false);

		protected Socket socket;

		public TCPServer(int port = 23)
		{
			led0.Write(false);
			led1.Write(false);
			led2.Write(false);

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(new IPEndPoint(IPAddress.Any, port));
			socket.Listen(1);

			led0.Write(true);
		}

		public void Listen()
		{
			byte[] buffer = new byte[250];

			using (Socket client = socket.Accept())
			{
				while (true)
				{
					led1.Write(true);

					if (client.Available > 0)
					{
						led2.Write(true);
						
						int received = client.Receive(buffer, buffer.Length, SocketFlags.None);

						Debug.Print("RECEIVED BYTES: " + received.ToString());
						Debug.Print("RECEIVED: " + (new string(Encoding.UTF8.GetChars(buffer))).Substring(0,received));

						Thread.Sleep(100);

						led2.Write(false);
					}
				}
			}
		}

		void IDisposable.Dispose()
		{
			if (socket != null)
			{
				socket.Close();
			}
		}

	}
}
