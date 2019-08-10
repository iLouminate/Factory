using iLouminate.AssemblyFactory.Example.Services.Encoders;
using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.EncoderTypes
{
	public class ChromeEncoder : IEncoder
	{
		private readonly ISha256Service shaService;
		
		public ChromeEncoder(ISha256Service shaService)
		{
			this.shaService = shaService;
		}

		public bool IsCompatible(IUser user) => user is ChromeUser;

		public string EncodePassword(string password)
		{
			return $"Chrome SHA256: {shaService.SHA256AsString(password)}";
		}
	}
}
