# Dependency Injection Factory Component

## Why
To enable you to create service based factories rapidly, without having to configure anything outside the factory.
## Installation
```

```

## Usage
```c#
public class Factory : AssemblyFactory<IFooObject>, IFactory
{
    public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
    {
    }
}

public class Factory : AssemblyFactory, IFactory
{
    public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory,
        new Type[] { typeof(IFooObject), typeof(IAnotherFooObject) })
    {
    }
}
```

## Example
Also see the example project inside solution.

```
public class Factory : AssemblyFactory<IFooObject>, IFactory
{
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
	{
	}
    
	public void ImplementationOne(ISomething something)
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

	public void ImplementationOne(ISomething something)
	{
		return GetImplementation<IFooObject>().Single(q => q.IsCompatible(something));
	}
    
	public void ImplementationTwo(ISomething something)
	{
		return GetImplementation<IAnotherFooObject>().Single(q => q.IsCompatible(something));
	}
}

public interface IFooObject
{
	bool IsCompatible(ISomething something);
}

// This will be created by the factory with Dependency Injection
public class FooObjectOne : IFooObject
{
	private readonly ISomeDIService someDIService;

	public FooObjectOne(ISomeDIService someDIService)
	{
		this.someDIService = someDIService;
	}

	public bool IsCompatible(ISomething something) => (something is SomethingOne);
}

// This will be created by the factory with Dependency Injection
public class FooObjectTwo : IFooObject
{
    private readonly ISomeDIService someDIService;

    public FooObjectTwo(ISomeDIService someDIService)
    {
      this.someDIService = someDIService;
    }

    public bool IsCompatible(ISomething something) => (something is SomethingTwo);
}

// This will be created by the factory with Dependency Injection
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
