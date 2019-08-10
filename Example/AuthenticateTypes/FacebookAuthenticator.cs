using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.AuthenticateTypes
{
	public class FacebookAuthenticator : IAuthenticator
	{
		private readonly IFacebookAuthenticatorService facebookAuthenticatorService;

		public FacebookAuthenticator(IFacebookAuthenticatorService facebookAuthenticatorService)
		{
			this.facebookAuthenticatorService = facebookAuthenticatorService;
		}

		public bool IsCompatible(IUser user) => user is FacebookUser;

		public bool Authenticate(IUser user)
		{
			if (!IsCompatible(user))
			{
				throw new ArgumentException("Incorrect User Type", nameof(user));
			}

			return facebookAuthenticatorService.Authenticate(((FacebookUser)user).FacebookAuthToken);
		}
	}
}
