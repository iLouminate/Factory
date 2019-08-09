using System;
using System.Security.Cryptography;
using System.Text;

namespace iLouminate.AssemblyFactory.Example.Services.Encoders
{
	public class Sha256Service : ISha256Service
	{
		public string SHA256AsString(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			using (SHA256 hash = SHA256.Create())
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
