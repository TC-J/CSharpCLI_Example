
# Setting Up a CLI App on Linux 
Install .NET software with package manager.

Link https://learn.microsoft.com/en-us/dotnet/core/install/linux

Init a directory with .NET CLI
```
$ dotnet new console --framework net6.0
```

Add System.CommandLine package.
```
$ dotnet add package System.CommandLine --prerelease
```

Build Application. The name comes from the main namespace.
```
$ dotnet build
# ./bin/debug/net6.0/<appname> <-- executable
```

Run Application via CLI
```
$ dotnet run -- <cli> # eg --file Program.cs
```
