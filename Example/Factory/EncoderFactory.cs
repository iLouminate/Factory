using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.UserTypes;
using iLouminate.AssemblyFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public class EncoderFactory : AssemblyFactory, IEncoderFactory
	{
		// IServiceScopeFactory is used to get services that have been added with AddScoped, AddTransient (see Startup.cs).
		public EncoderFactory(IServiceScopeFactory scopedFactory) : base(scopedFactory, new Type[] { typeof(IEncoder), typeof(IUser) })
		{ }

		public IEncoder GetEncoder(IUser user)
		{
			var encoders = GetImplementation<IEncoder>();
			var users = GetImplementation<IUser>().ToList();
			return encoders.Single(q => q.IsUserCompatible(user));
		}
	}
}
