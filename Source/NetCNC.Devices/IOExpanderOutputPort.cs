using System;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Devices
{
	public class IOExpanderOutputPort : IDigitalOutputPort
	{
		protected IIOExpander ioExpander;
		protected int pinNbr;

		public IOExpanderOutputPort(IIOExpander ioExpander, int pinNbr)
		{
			this.ioExpander = ioExpander;
			this.pinNbr = pinNbr;
		}

		void IDigitalOutputPort.Write(bool value)
		{
			this.ioExpander.Write(pinNbr,value);
		}

		bool IDigitalOutputPort.Read()
		{
			return this.ioExpander.Read(pinNbr);
		}
	}
}
