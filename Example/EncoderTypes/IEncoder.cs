using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.EncoderTypes
{
	public interface IEncoder
    {
		bool IsCompatible(IUser user);
		string EncodePassword(string user);
	}
}
