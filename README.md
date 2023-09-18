# Foundational-C#-with-Microsoft-by-freeCodeCamp

## Dotnet-Debug-101

### Part of Curriculum for freeCodeCamps's Foundational C# with Microsoft training and certification

## To create new console application:

```
dotnet new console -o ./{App-Name}/
```

## To run console application:

```
dotnet run
```

## To clean console application build files:

```
dotnet clean
```

## To build console application build files:

```
dotnet build
```

## To create new console application solution:

```c#
// on the same level as the file with extension .csproj
dotnet new solution
```

OR

```c#
// on the same level as the file with extension .csproj
dotnet new sln
```

## To debug your console application, configuration needs to be done in `launch.json` file inside `.vscode` at root folder in your project. Example config as below:

```c#
{
  // Use IntelliSense to learn about possible attributes.
  // Hover to view descriptions of existing attributes.
  // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Launch {Insert Project Name} (console)",
      "type": "coreclr",
      "request": "launch",
      // "preLaunchTask": "build", this causing build issues during debug process initiation
      "program": "${workspaceFolder}/{Insert Project Name}/bin/Debug/net7.0/{Insert Project Name}.dll",
      "args": [],
      "cwd": "${workspaceFolder}",
      "stopAtEntry": false,
      "console": "integratedTerminal", // or externalTerminal to enable debug user input variable's such as Console.ReadLine();
      "requireExactSource": false
    },
  ]
}
// Now you can start to debug the project under DEBUG & RUN tab for this project
```
