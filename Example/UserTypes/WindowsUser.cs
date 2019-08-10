namespace iLouminate.AssemblyFactory.Example.UserTypes
{
	public class WindowsUser : BaseUser
	{
		public WindowsAuthKey WindowsAuth { get; set; }
	}

	public class WindowsAuthKey
	{
		public string Key { get; set; }
	}
}
