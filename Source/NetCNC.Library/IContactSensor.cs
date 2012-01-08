
namespace NetCNC.Library
{
	public interface IContactSensor
	{
		void Subscribe(ContactSensorListener listener);
		bool IsSame(ContactSensor sensor);
		bool GetState();
	}
}
