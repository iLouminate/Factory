using iLouminate.AssemblyFactory.Example.Factory;
using iLouminate.AssemblyFactory.Example.UserTypes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace iLouminate.AssemblyFactory.Example.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly IEncoderFactory encoderFactory;
		private readonly IAuthenticatorFactory authenticatorFactory;

		public ValuesController(IEncoderFactory encoderFactory, IAuthenticatorFactory authenticatorFactory)
		{
			this.encoderFactory = encoderFactory;
			this.authenticatorFactory = authenticatorFactory;
		}

		// GET api/values/facebook
		[HttpGet]
		[Route("{action}")]
		public ActionResult<IEnumerable<string>> Facebook()
		{
			var result = new List<string>();

			IUser fbUser = new FacebookUser() { Username = "Test@fb.com", Password = "test123", FacebookAuthToken = new FacebookAuthToken { Token = "facebook" } };

			result.Add(encoderFactory.GetEncoder(fbUser).EncodePassword(fbUser.Password));
			if (authenticatorFactory.GetAuthenticator(fbUser).Authenticate(fbUser))
				result.Add("Authenticated!");
			else
				result.Add("Not Authenticated!");
			return result;
		}

		// GET api/values/chrome
		[HttpGet]
		[Route("{action}")]
		public ActionResult<IEnumerable<string>> Chrome()
		{
			var result = new List<string>();
			
			IUser gglUser = new ChromeUser() { Username = "Test@chrome.com", Password = "test123", ChromeApiKey = new ChromeApiKey { Key = "chrome" } };
			
			result.Add(encoderFactory.GetEncoder(gglUser).EncodePassword(gglUser.Password));
			if (authenticatorFactory.GetAuthenticator(gglUser).Authenticate(gglUser))
				result.Add("Authenticated!");
			else
				result.Add("Not Authenticated!");

			return result;
		}

		// GET api/values/windows
		[HttpGet]
		[Route("{action}")]
		public ActionResult<IEnumerable<string>> Windows()
		{
			var result = new List<string>();
			
			IUser winUser = new WindowsUser() { Username = "Test@win.com", Password = "test123", WindowsAuth = new WindowsAuthKey { Key = "windows" } };
			
			result.Add(authenticatorFactory.GetEncoder(winUser).EncodePassword(winUser.Password));
			if (authenticatorFactory.GetAuthenticator(winUser).Authenticate(winUser))
				result.Add("Authenticated!");
			else
				result.Add("Not Authenticated!");

			return result;
		}
	}
}
