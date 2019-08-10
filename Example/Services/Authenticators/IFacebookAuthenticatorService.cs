using iLouminate.AssemblyFactory.Example.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.Services.Authenticators
{
	public interface IFacebookAuthenticatorService
	{
		bool Authenticate(FacebookAuthToken token);
	}
}
