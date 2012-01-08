using System;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Devices
{
	public class CPUOutputPort : IDigitalOutputPort
	{
		protected OutputPort outputPut;

		public CPUOutputPort(OutputPort outputPut)
		{
			this.outputPut = outputPut;
		}

		public CPUOutputPort(Cpu.Pin outputPin) :
			this(outputPin, false)
		{
		}

		public CPUOutputPort(Cpu.Pin outputPin, bool initalState)
		{
			this.outputPut = new OutputPort(outputPin, initalState);
		}

		void IDigitalOutputPort.Write(bool value)
		{
			this.outputPut.Write(value);
		}

		bool IDigitalOutputPort.Read()
		{
			return this.outputPut.Read();
		}
	}
}
