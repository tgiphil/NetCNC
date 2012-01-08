using System;
using Microsoft.SPOT;

namespace NetCNC.Devices
{
	public class PCA9555N : IIOExpander
	{
		// TODO
		void IIOExpander.Write(int pinNbr, bool value) { }
		bool IIOExpander.Read(int pinNbr) { return false; }

	}
}
