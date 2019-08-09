using iLouminate.AssemblyFactory.Example.UserTypes;

namespace iLouminate.AssemblyFactory.Example.EncoderTypes
{
	public class WindowsEncoder : IEncoder
	{
		public bool IsUserCompatible(IUser user) => (user is WindowsUser);

		public string EncodePassword(string password)
		{
			return $"Windows Plain: {password}"; // plain text, no encoding for test purposes.
		}
	}
}
