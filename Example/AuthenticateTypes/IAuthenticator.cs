using iLouminate.AssemblyFactory.Example.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.AuthenticateTypes
{
	public interface IAuthenticator
	{
		bool IsCompatible(IUser user);
		bool Authenticate(IUser user);
	}
}
