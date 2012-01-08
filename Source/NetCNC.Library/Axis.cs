using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Library
{
	public class Axis : IAxis
	{

		protected IStepMotor stepMotor;
		protected bool direction;

		protected char label;

		protected int location;	// in mm * 10000 (for now)
		protected int ratio; // x 1000 (for now) : belt_pitch / XY: pulley_number_of_teeth or Z:thread_pitch

		protected IContactSensor minimumSensor;
		protected IContactSensor maximumSensor;

		public Axis(char label, IStepMotor stepMotor, IContactSensor commonSensor) :
			this(label, stepMotor, commonSensor, commonSensor)
		{
		}

		public Axis(char label, IStepMotor stepMotor, IContactSensor minimumSensor, IContactSensor maximumSensor)
		{
			this.stepMotor = stepMotor;
			this.direction = false;
			this.minimumSensor = minimumSensor;
			this.maximumSensor = maximumSensor;
			this.label = label;

			stepMotor.Direction = direction;
		}

		int IAxis.Location { get { return location; } }
		int IAxis.Ratio { get { return ratio; } set { ratio = value; } }

		bool IAxis.Direction
		{
			get { return direction; }
			set
			{
				direction = value;
				stepMotor.Direction = direction;
			}
		}

		void IAxis.Step()
		{
			stepMotor.Step();

			if (direction)
				location++;
			else
				location--;
		}

		bool Calibrate()
		{
			if (minimumSensor == null || maximumSensor == null)
				return false;

			if (minimumSensor.GetState() || maximumSensor.GetState())
				return false;

			bool originalDirection = direction;

			// Go towards minimum
			direction = false;

			while (true)
			{
				if (minimumSensor.GetState())
				{
					location = 0;
					return true;
				}

				if (maximumSensor.GetState())
				{
					// not expected, sensor must be incorrect
					return false;
				}

				stepMotor.Step();
			}

		}
	}
}
