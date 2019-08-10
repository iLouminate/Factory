using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.AuthenticateTypes
{
	public class ChromeAuthenticator : IAuthenticator
	{
		private readonly IChromeAuthenticatorService chromeAuthenticatorService;

		public ChromeAuthenticator(IChromeAuthenticatorService chromeAuthenticatorService)
		{
			this.chromeAuthenticatorService = chromeAuthenticatorService;
		}

		public bool IsCompatible(IUser user) => user is ChromeUser;

		public bool Authenticate(IUser user)
		{
			if (!IsCompatible(user))
			{
				throw new ArgumentException("Incorrect User Type", nameof(user));
			}

			return chromeAuthenticatorService.Authenticate(((ChromeUser)user).ChromeApiKey);
		}
	}
}
