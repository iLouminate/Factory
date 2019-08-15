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

			using (IServiceScope scope = scopedFactory.CreateScope())
			{
				var interfaceType = typeof(T);
				var assemblyTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => interfaceType.IsAssignableFrom(p));
				foreach (var assemblyType in assemblyTypes.Where(t => t.IsInterface == false && t.IsClass == true && t.IsAbstract == false))
				{
					/// Note: if more than one constructor is used, will try to resolve first in file.
					/// Does not support classes where constructor has non-Dependency Injection parameters.
					/// e.g.: 
					/// - Foo(IService service) will work
					/// - Foo(IService service, string name) will fail
					var initializedClass = ActivatorUtilities.CreateInstance(scope.ServiceProvider, assemblyType) as T;
					implementations.Add(initializedClass);
				}
			}
		}

		public AssemblyFactory()
		{
			if (!typeof(T).IsInterface) throw new AssemblyFactoryException($"Supplied GenericType in AssemblyFactory<{typeof(T)}> can only be an interface.");
			
			var interfaceType = typeof(T);
			var assemblyTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => interfaceType.IsAssignableFrom(p));
			foreach (var assemblyType in assemblyTypes.Where(t => t.IsInterface == false && t.IsClass == true && t.IsAbstract == false))
			{
				/// Note: if more than one constructor is used, will try to resolve first in file.
				/// Does not support classes where constructor has non-Dependency Injection parameters.
				/// e.g.: 
				/// - Foo(IService service) will work
				/// - Foo(IService service, string name) will fail
				var initializedClass = Activator.CreateInstance(assemblyType) as T;
				implementations.Add(initializedClass);
			}
		}
	}
}
