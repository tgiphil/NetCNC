
namespace NetCNC.Library
{
	public interface IAxis
	{
		int Location { get; }
		bool Direction { get; set; }
		int Ratio { get; set; }

		void Step();
	}
}
