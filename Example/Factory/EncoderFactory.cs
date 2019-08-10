using iLouminate.AssemblyFactory.Example.EncoderTypes;
using iLouminate.AssemblyFactory.Example.UserTypes;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace iLouminate.AssemblyFactory.Example.Factory
{
	public class EncoderFactory : AssemblyFactory<IEncoder>, IEncoderFactory
	{
		// IServiceScopeFactory is used to get services that have been added with AddScoped, AddTransient (see Startup.cs).
		public EncoderFactory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
		{ }

		public IEncoder GetEncoder(IUser user)
		{
			return implementations.SingleOrDefault(q => q.IsCompatible(user));
		}
	}
}
