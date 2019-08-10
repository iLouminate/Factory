using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Services.Authenticators
{
	public class WindowsAuthenticatorService : IWindowsAuthenticatorService
	{
		public bool Authenticate(WindowsAuthKey key)
		{
			if (key?.Key != null)
			{
				return key.Key == "windows";
			}
			return false;
		}
	}
}
