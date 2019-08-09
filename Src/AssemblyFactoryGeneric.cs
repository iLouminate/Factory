using iLouminate.AssemblyFactory.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iLouminate.AssemblyFactory
{
	public abstract class AssemblyFactory<T> where T : class
	{
		protected List<T> implementations = new List<T>();

		public AssemblyFactory(IServiceScopeFactory scopedFactory)
		{
			if (scopedFactory == null) throw new ArgumentNullException(nameof(scopedFactory));
			if (!typeof(T).IsInterface) throw new AssemblyFactoryException($"Supplied GenericType in AssemblyFactory<{typeof(T)}> can only be an interface.");

			var scope = scopedFactory.CreateScope();
			var interfaceType = typeof(T);
			var assemblyTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => interfaceType.IsAssignableFrom(p));
			foreach (var assemblyType in assemblyTypes.Where(t => t.IsInterface == false && t.IsClass == true))
			{
				/// Note: if more than one constructor is used, will try to resolve first in file.
				var initializedClass = ActivatorUtilities.CreateInstance(scope.ServiceProvider, assemblyType) as T;
				implementations.Add(initializedClass);
			}
		}
	}
}
