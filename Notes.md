## Checking the .NET SDK

- Check .NET version: `dotnet --version`
- List available SDKs: `dotnet --list-sdks`

## Creating a Web API Project

- Create project: `dotnet new webapi -n *folder name* -controllers`
- Navigate to project: `cd *folder name*`
- Open in VS Code: `code .`

## Building and running the project

- Building the project: `dotnet build`
- Running the project: `dotnet run`
- Support HTTPS: `dotnet dev-certs https --trust`
- Hot reload: `dotnet watch`

## HTTPRepl test APIs

- Install HttpRepl: `dotnet tool install -g Microsoft.dotnet-httprepl`
- Command to connect API: `httprepl http://localhost:5091 (URL application)`
- Command lists endpoints: http://localhost:5091/> `ls or dir`
- CD command to navigate endpoints: `cd (endpoints ex. WeatherForecast)`
- Command get or prefer http method: http://localhost:5091/WeatherForecast> `get`

## Debugging in VSCode

- Setting up debugging: `Ctrl + Shift + P` (.NET: Generate Assets for Build and Debug)

## Asp.Net Codegenerator (Setting up tool to generate file in project and command)

- Install the tool: `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 8.*` and `dotnet tool install -g dotnet-aspnet-codegenerator --version 8.*`
- Restore and Verify it was added: `dotnet restore` and `dotnet list package`
- Command to generate a controller: `dotnet-aspnet-codegenerator controller -name PostsController -api -outDir Controllers`

## .NET Core CLI - EF Core packages

- Install the dotnet-ef tool: `dotnet tool install --globall dotnet-ef`
- Install EF Core packages: `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` and `dotnet add package Microsoft.EntityFrameworkCore.Design`

## Creating the database migrationn

- Install the command: `dotnet ef migrations add InitialDb`
