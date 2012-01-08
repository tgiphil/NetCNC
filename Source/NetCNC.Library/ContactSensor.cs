using System;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Library
{
	public delegate void ContactSensorListener(bool state, DateTime time);

	public class ContactSensor : IContactSensor
	{
		protected InterruptPort sensorPort;
		protected event ContactSensorListener listeners;
		protected Cpu.Pin sensorPin;

		public ContactSensor(Cpu.Pin sensorPin)
		{
			this.sensorPin = sensorPin;

			sensorPort = new InterruptPort(sensorPin, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeLevelLow);
			sensorPort.OnInterrupt += new NativeEventHandler(OnInterrupt);
		}

		private void OnInterrupt(uint data1, uint data2, DateTime time)
		{
			listeners(data2 == 0, time);
			sensorPort.ClearInterrupt();
		}

		void IContactSensor.Subscribe(ContactSensorListener listener)
		{
			listeners += listener;
		}

		bool IContactSensor.IsSame(ContactSensor sensor)
		{
			return sensorPin == sensor.sensorPin;
		}

		bool IContactSensor.GetState()
		{
			return sensorPort.Read();
		}

	}
}
