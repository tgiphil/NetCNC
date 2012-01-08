
namespace NetCNC.Library
{
	public interface IStepMotor
	{
		int StepsPerRevolution { get; }
		int MotorSteps { get; }
		StepResolution StepResolution { get; }

		bool Direction { get; set; }
		void Step();
	}
}
