using iLouminate.AssemblyFactory.Example.AuthenticateTypes;
using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.UserTypes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public class AuthenticatorFactory : AssemblyFactory, IAuthenticatorFactory
	{
		// IServiceScopeFactory is used to get services that have been added with AddScoped, AddTransient (see Startup.cs).
		public AuthenticatorFactory(IServiceScopeFactory scopedFactory) : base(scopedFactory, new Type[] { typeof(IEncoder), typeof(IAuthenticator) })
		{ }

		public IEncoder GetEncoder(IUser user)
		{
			return GetImplementation<IEncoder>().SingleOrDefault(q => q.IsCompatible(user));
		}

		public IAuthenticator GetAuthenticator(IUser user)
		{
			return GetImplementation<IAuthenticator>().SingleOrDefault(q => q.IsCompatible(user));
		}
	}
}
