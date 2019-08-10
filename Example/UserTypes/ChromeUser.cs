namespace iLouminate.AssemblyFactory.Example.UserTypes
{
	public class ChromeUser : BaseUser
    {
		public ChromeApiKey ChromeApiKey { get; set; }
		
	}

	public class ChromeApiKey
	{
		public string Key { get; set; }
	}
}
