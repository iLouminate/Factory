using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public interface IEncoderFactoryGeneric
	{
		IEncoder GetEncoder(IUser user);
	}
}
