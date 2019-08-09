# Dependency Injection Factory Component

## Why
To enable you to create service based factories rapidly, without having to configure every class specifically.

Before you would do something like:
```c#
switch(type)
{
  typeof(A): return new A();
  typeof(B): return new B();
  typeof(C): return new C();
}

List<Interface> availableTypes = new List<Interface>();
availableTypes.Add(new A());
availableTypes.Add(new B());
availableTypes.Add(new C());
```
But now you can easily just give the interface you want to use and it will read the assembly for all classes using that specific interface and will automatically this to your factory.

## Installation
```

```

## Usage
```c#
public class Factory : AssemblyFactory<IFooObject>, IFactory
{
	// IServiceScopeFactory is required for accessing services from the (Startup.cs) AddScoped<>,AddTransient<>
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
	{
	}
	
	public void DoSomething()
	{
		// List<IFooObject> 
		implementations // List of classes known inside factory
		
		WhateverClassYouWant wecyw = implementations.Single(i => typeof(i) == typeof(WhateverClassYouWant))
	}
}

public class Factory : AssemblyFactory, IFactory
{
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory,
		new Type[] { typeof(IFooObject), typeof(IAnotherFooObject) })
	{
	}
	
	public void DoSomething()
	{
		// List<IFooObject> 
		GetImplementation<IFooObject>() // List of classes known inside factory
	}
	
	public void DoSomething()
	{
		// List<IAnotherFooObject>
		GetImplementation<IAnotherFooObject>() // List of classes known inside factory
	}
	
}
```

## Example
Also see the example project inside solution.

```c#
public class Factory : AssemblyFactory<IFooObject>, IFactory
{
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
	{
	}
	
    	// This will return the IFooObject interface with a FooObject as actual class depending on the .Single(...)
	public IFooObject ImplementationOne(ISomething something)
	{
		return implementations.Single(q => q.IsCompatible(foo));
	}
}

public class Factory : AssemblyFactory, IFactory
{
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory, 
		new Type[] { typeof(IFooObject), typeof(IAnotherFooObject) })
	{
	}
	
	// This will return the IFooObject interface with a FooObject as actual class depending on the .Single(...)
	public IFooObject ImplementationOne(ISomething something)
	{
		return GetImplementation<IFooObject>().Single(q => q.IsCompatible(something));
	}
    	
	// This will return the IFooObject interface with AnotherFooObject as actual class
	public IFooObject ImplementationTwo(ISomething something)
	{
		return GetImplementation<IAnotherFooObject>().Single(q => q.IsCompatible(something));
	}
}

public interface IFooObject
{
	bool IsCompatible(ISomething something);
}

public class FooObjectOne : IFooObject
{
	private readonly ISomeDIService someDIService;

	public FooObjectOne(ISomeDIService someDIService)
	{
		this.someDIService = someDIService;
	}

	public bool IsCompatible(ISomething something) => (something is SomethingOne);
}

public class FooObjectTwo : IFooObject
{
	private readonly ISomeDIService someDIService;

	public FooObjectTwo(ISomeDIService someDIService)
	{
		this.someDIService = someDIService;
	}

	public bool IsCompatible(ISomething something) => (something is SomethingTwo);
}

public class AnotherFooObject : IAnotherFooObject
{
	private readonly ISomeDIService someDIService;

	public FooObjectTwo(ISomeDIService someDIService)
	{
		this.someDIService = someDIService;
	}

	public bool IsCompatible(ISomething something) => (something is SomethingTwo);
}

public class SomethingOne : ISomething
{
	public string Name { get; set; }
}

public class SomethingTwo : ISomething
{
	public string Name { get; set; }
}
```
