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
		private readonly IEncoderFactoryGeneric genericEncoderFactory;

		public ValuesController(IEncoderFactory encoderFactory, IEncoderFactoryGeneric genericEncoderFactory)
		{
			this.encoderFactory = encoderFactory;
			this.genericEncoderFactory = genericEncoderFactory;
		}

		// GET api/values
		[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
			var result = new List<string>();

			IUser fbUser = new FacebookUser() { Username = "Test@fb.com", Password = "test123" };
			IUser gglUser = new ChromeUser() { Username = "Test@chrome.com", Password = "test123" };
			IUser winUser = new WindowsUser() { Username = "Test@win.com", Password = "test123" };

			result.Add(genericEncoderFactory.GetEncoder(fbUser).EncodePassword(fbUser.Password));
			result.Add(genericEncoderFactory.GetEncoder(gglUser).EncodePassword(gglUser.Password));
			result.Add(genericEncoderFactory.GetEncoder(winUser).EncodePassword(winUser.Password));
			var a = encoderFactory.GetEncoder(fbUser);

			return result;
		}
    }
}
