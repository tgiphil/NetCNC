using System;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Devices
{
	public class CPUInputPort : IDigitalInputPort
	{
		protected InputPort inputPut;

		public CPUInputPort(InputPort inputPut)
		{
			this.inputPut = inputPut;
		}

		public CPUInputPort(Cpu.Pin inputPin, bool glitchFilter, Port.ResistorMode resister)
		{
			this.inputPut = new InputPort(inputPin, glitchFilter, resister);
		}

		bool IDigitalInputPort.Read()
		{
			return this.inputPut.Read();
		}
	}
}
