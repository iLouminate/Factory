using iLouminate.AssemblyFactory.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iLouminate.AssemblyFactory
{
	public abstract class AssemblyFactory
	{
		protected Dictionary<Type, List<object>> implementations = new Dictionary<Type, List<object>>();

		protected List<T> GetImplementation<T>()
		{
			
			if (implementations.TryGetValue(typeof(T), out List<object> implementation))
			{
				List<T> result = new List<T>();
				implementation.ForEach(item =>
				{
					result.Add((T)item);
				});
				return result;
			}
			return default(List<T>);
		}

		public AssemblyFactory(IServiceScopeFactory scopedFactory, IEnumerable<Type> types)
		{
			if (scopedFactory == null) throw new ArgumentNullException(nameof(scopedFactory));
			if (types == null) throw new ArgumentNullException(nameof(types));
			if (types.Any(q => !q.IsInterface)) throw new AssemblyFactoryException("Can only expect interfaces");
			
			var scope = scopedFactory.CreateScope();
			foreach (var type in types.ToList())
			{
				var implementationList = new List<object>();
				var assemblyTypes = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p));
				foreach (var assemblyType in assemblyTypes.Where(t => t.IsInterface == false && t.IsClass == true))
				{
					/// Note: if more than one constructor is used, will try to resolve first in file.
					var initializedClass = ActivatorUtilities.CreateInstance(scope.ServiceProvider, assemblyType);
					implementationList.Add(initializedClass);
				}
				implementations.Add(type, implementationList);
			}

		}

	}
}
