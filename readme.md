# Dependency Injection Factory Component

C# Version of https://github.com/aeviiq/factory

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
But now you can easily just give the interface you want to use and it will read the assembly for all classes using that specific interface and will automatically resolve this based on an incoming type.

NOTE: Only supports empty constructors and constructors using Dependency Injection. See below:
```c#
public ChromeEncoder() // Success
public ChromeEncoder(ISha256Service shaService) // Success
public ChromeEncoder(ISha256Service shaService, string name) // Error
public ChromeEncoder(string name) // Error
```

## Installation
```
-- Package Manager
Install-Package iLouminate.AssemblyFactory -Version 1.0.1

-- .NET CLI
dotnet add package iLouminate.AssemblyFactory --version 1.0.1

-- Package Reference
<PackageReference Include="iLouminate.AssemblyFactory" Version="1.0.1" />
```

## Usage
Using Generic Interface
```c#
public class EncoderFactory : AssemblyFactory<IFooObject>, IFactory
{
	// IServiceScopeFactory is required for accessing services from the (Startup.cs) AddScoped<>,AddTransient<>
	// IServiceScopeFactory is not needed if you use classes that do not require dependency injection.
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory)
	{
	}
	
	public IEncoder GetEncoder(IUser user)
	{
		// List<IEncoder> implementations is list of all Classes that implement IEncoder
		// Will return the correct encoder for the provider user.
		return implementations.SingleOrDefault(i => i.IsCompatible(user));
	}
}
```

Using Enumerable with multiple Interfaces
```c#
public class AuthenticationFactory : AssemblyFactory, IFactory
{
	public Factory(IServiceScopeFactory scopedFactory) : base(scopedFactory,
		new Type[] { typeof(IEncoder), typeof(IAuthenticator) })
	{
	}
	
	public IEncoder GetEncoder(IUser user)
	{
		GetImplementation<IEncoder>().SingleOrDefault(i => i.IsCompatible(user));
	}
	
	public IAuthenticator GetAuthenticator(IUser user)
	{
		GetImplementation<IAuthenticator>().SingleOrDefault(i => i.IsCompatible(user));
	}
	
}
```

How to implement Checking for correct IUser
```c#
// This a method of the IEncoder/IAuthenticator Interface. (multiple possibilities/examples)
public bool IsCompatible(IUser user) => user is FacebookUser;
public bool IsCompatible(IUser user) => user is ChromeUser;
public bool IsCompatible(IUser user) => user is WindowsUser;

// Another example
public bool IsCompatible(IUser user)
{
	if(user is ChromeUser)
		return user.Username.contains("@gmail.com")
	return false;
}

```
## Example
Examples are included in the solution.
