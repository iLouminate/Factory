using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iLouminate.AssemblyFactory.Example.UserTypes
{
	public abstract class BaseUser : IUser
	{
		public string Password { get; set; }
		public string Username { get; set; }
	}
}
