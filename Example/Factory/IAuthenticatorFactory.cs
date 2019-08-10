using iLouminate.AssemblyFactory.Example.AuthenticateTypes;
using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public interface IAuthenticatorFactory
	{
		IEncoder GetEncoder(IUser user);
		IAuthenticator GetAuthenticator(IUser user);
	}
}