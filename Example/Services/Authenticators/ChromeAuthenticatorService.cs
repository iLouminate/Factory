using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.Services.Authenticators
{
	public class ChromeAuthenticatorService : IChromeAuthenticatorService
	{	
		public bool Authenticate(ChromeApiKey apiKey)
		{
			if (apiKey?.Key != null)
			{
				return apiKey.Key == "chrome";
			}
			return false;
		}
	}
}
