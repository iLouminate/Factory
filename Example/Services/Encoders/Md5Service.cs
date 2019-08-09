using System;
using System.Security.Cryptography;
using System.Text;

namespace iLouminate.AssemblyFactory.Example.Services.Encoders
{
	public class Md5Service : IMd5Service
    {
		public string Md5AsString(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			using (MD5 hash = MD5.Create())
			{
				Encoding encoding = Encoding.UTF8;
				Byte[] result = hash.ComputeHash(encoding.GetBytes(value));
				foreach (Byte b in result)
					stringBuilder.Append(b.ToString("x2"));
			}

			return stringBuilder.ToString();
		}
	}
}
