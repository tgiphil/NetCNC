using System;
using Microsoft.SPOT;

namespace NetCNC.Devices
{
	public interface IIOExpander
	{
		void Write(int pinNbr, bool value);
		bool Read(int pinNbr);
		//bool ConfigurePort(int pinNbr, bool read);

	}

}
