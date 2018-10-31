# Small Commits Workshop

## Getting Started

* Clone this repo
* Set up .NET Core for Visual Studio 2017 via the [.NET Core
  Guide](https://docs.microsoft.com/en-us/dotnet/core/windows-prerequisites?tabs=netcore21#prerequisites-with-visual-studio-2017)
* Open `SmallCommitsWorkshop.sln` using Visual Studio 2017
* Run the tests in the `SmallCommitsWorkshopTests` project
  * Required: ReSharper or [NUnit 3 Test
    Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter)
* Start the app by clicking on the green arrow with label `IIS Express`
* While the app is running, navigate to `/api/users`. You should see the
  following response:

```json
{"169":{"id":169,"userName":"D2LSupport","isActive":true},"175":{"id":175,"userName":"user1","isActive":false}}
```

Note: the app uses a self-signed certificate, and you may see warnings about it.
It is safe in this specific instance to ignore the errors.

### Visual Studio Alternative

If you do not have or want to use Visual Studio, make sure you have [.Net Core
2.1
SDK](https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.403-windows-x64-installer)
installed.

You can test the app by running:

```cmd
dotnet test SmallCommitsWorkshopTests\SmallCommitsWorkshopTests.csproj
```

You can run the app by running:

```cmd
dotnet run --project SmallCommitsWorkshop\SmallCommitsWorkshop.csproj
```
