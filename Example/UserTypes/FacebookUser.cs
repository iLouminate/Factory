namespace iLouminate.AssemblyFactory.Example.UserTypes
{
	public class FacebookUser : BaseUser
	{
		public FacebookAuthToken FacebookAuthToken { get; set; }
	}

	public class FacebookAuthToken
	{
		public string Token { get; set; }
	}
}
