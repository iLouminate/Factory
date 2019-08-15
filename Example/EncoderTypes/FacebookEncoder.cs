using iLouminate.AssemblyFactory.Example.Services.Encoders;
using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.EncoderTypes
{
	public class FacebookEncoder : IEncoder
	{
		private readonly IMd5Service md5Service;

		public FacebookEncoder(IMd5Service md5Service)
		{
			this.md5Service = md5Service;
		}

		public FacebookEncoder()
		{

		}

		public bool IsCompatible(IUser user) => user is FacebookUser;

		public string EncodePassword(string password)
		{

			return $"Facebook MD5: {md5Service?.Md5AsString(password)}";
		}
	}
}
