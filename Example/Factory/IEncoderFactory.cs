using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public interface IEncoderFactory
	{
		IEncoder GetEncoder(IUser user);
	}
}
