using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace NetCNC.Library
{
	public class StepMotor : IStepMotor
	{
		protected IDigitalOutputPort stepPort;
		protected IDigitalOutputPort directionPort;

		protected bool direction;
		protected int motorSteps; // excluding the step resolution
		protected StepResolution stepResolution;

		int IStepMotor.MotorSteps { get { return motorSteps; } }
		int IStepMotor.StepsPerRevolution { get { return motorSteps * (int)stepResolution; } }
		StepResolution IStepMotor.StepResolution { get { return stepResolution; } }

		public StepMotor(IDigitalOutputPort stepPort, IDigitalOutputPort directionPort, int motorSteps, StepResolution stepResolution)
		{
			this.direction = false;
			this.stepResolution = stepResolution;
			this.motorSteps = motorSteps;
			this.stepPort = stepPort;
			this.directionPort = directionPort;
		}

		bool IStepMotor.Direction
		{
			get
			{
				return direction;
			}
			set
			{
				direction = value;
				directionPort.Write(direction);
			}
		}

		void IStepMotor.Step()
		{
			stepPort.Write(true);
			stepPort.Write(false);
		}

	}
}
