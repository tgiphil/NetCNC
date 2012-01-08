
namespace NetCNC.Devices
{
	public interface IDigitalPort
	{
	}

	public interface IDigitalInputPort
	{
		bool Read();
	}
	public interface IDigitalOutputPort
	{
		bool Read();
		void Write(bool value);
	}
}
