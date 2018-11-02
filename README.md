# Small Commits Workshop

[![Build status](https://ci.appveyor.com/api/projects/status/wvkbw0nvrgnr5h23/branch/master?svg=true)](https://ci.appveyor.com/project/neverendingqs/small-commits-workshop/branch/master)

Slides:
[https://neverendingqs.github.io/small-commits-workshop](https://neverendingqs.github.io/small-commits-workshop/#1)

## Getting Started

* Clone this repo
* Set up .NET Core 2.1 for Visual Studio 2017 via the [.NET Core
  Guide](https://docs.microsoft.com/en-us/dotnet/core/windows-prerequisites?tabs=netcore21#prerequisites-with-visual-studio-2017)
* Open `SmallCommitsWorkshop.sln` using Visual Studio 2017
* Run the tests in the `SmallCommitsWorkshopTests` project
  * Required: ReSharper or [NUnit 3 Test
    Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter)
* Start the app by clicking on the green arrow with label `IIS Express`
* This should launch the app in your browser and automatically navigate to the `/api/users` route.
  * If this doesn't work, contact Mark or Carl and they'll help you out.
* While on `/api/users/`, you should see the following response:

```json
{"169":{"id":169,"userName":"D2LSupport","isActive":true},"175":{"id":175,"userName":"user1","isActive":false}}
```

Note: the app uses a self-signed certificate, and you may see warnings about it.
It is safe in this specific instance to ignore the errors.

### OS / Visual Studio Alternatives

If you do not have or want to use Visual Studio, or do not want to use Windows,
simply install [.Net Core 2.1 SDK](https://www.microsoft.com/net/download) and
use your editor of choice.

```cmd
# Run tests
dotnet test SmallCommitsWorkshopTests\SmallCommitsWorkshopTests.csproj

# Run app
dotnet run --project SmallCommitsWorkshop\SmallCommitsWorkshop.csproj
```
