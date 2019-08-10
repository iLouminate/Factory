using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Services.Authenticators
{
	public class FacebookAuthenticatorService : IFacebookAuthenticatorService
	{
		public bool Authenticate(FacebookAuthToken token)
		{
			if (token?.Token != null)
			{
				return token.Token == "facebook";
			}
			return false;
		}
	}
}
