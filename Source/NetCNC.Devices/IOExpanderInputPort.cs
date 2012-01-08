using System;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Devices
{
	public class IOExpanderInputPort : IDigitalInputPort
	{
		protected IIOExpander ioExpander;
		protected int pinNbr;

		public IOExpanderInputPort(IIOExpander ioExpander, int pinNbr)
		{
			this.ioExpander = ioExpander;
			this.pinNbr = pinNbr;
		}

		bool IDigitalInputPort.Read()
		{
			return this.ioExpander.Read(pinNbr);
		}
	}
}
