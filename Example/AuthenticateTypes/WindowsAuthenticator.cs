using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.AuthenticateTypes
{
	public class WindowsAuthenticator : IAuthenticator
	{
		private readonly IWindowsAuthenticatorService windowsAuthenticatorService;

		public WindowsAuthenticator(IWindowsAuthenticatorService windowsAuthenticatorService)
		{
			this.windowsAuthenticatorService = windowsAuthenticatorService;
		}

		public bool IsCompatible(IUser user) => user is WindowsUser;

		public bool Authenticate(IUser user)
		{
			if (!IsCompatible(user))
			{
				throw new ArgumentException("Incorrect User Type", nameof(user));
			}

			return windowsAuthenticatorService.Authenticate(((WindowsUser)user).WindowsAuth);
		}
	}
}
