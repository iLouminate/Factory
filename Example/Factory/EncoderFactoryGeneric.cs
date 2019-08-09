using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.UserTypes;
using iLouminate.AssemblyFactory;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public class EncoderFactoryGeneric : AssemblyFactory<IEncoder>, IEncoderFactoryGeneric
	{
		// IServiceScopeFactory is used to get services that have been added with AddScoped, AddTransient (see Startup.cs).
		public EncoderFactoryGeneric(IServiceScopeFactory scopedFactory) : base(scopedFactory)
		{ }

		public IEncoder GetEncoder(IUser user)
		{
			return implementations.Single(q => q.IsUserCompatible(user));
		}
	}
}
