using System;
using System.Runtime.Serialization;

namespace iLouminate.AssemblyFactory.Exceptions
{
	public class AssemblyFactoryException : Exception
	{
		public AssemblyFactoryException()
		{
		}

		public AssemblyFactoryException(string message) : base(message)
		{
		}

		public AssemblyFactoryException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected AssemblyFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
