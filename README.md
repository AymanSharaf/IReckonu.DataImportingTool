# IRECKONU Assignment 

# Requirements
_Build a web app with the features described below._

_Backend - C# .NET Core web API_

_1. Import the file via web API, expect the file to be very large in production_

_2. Transform the data into a logical model_

_3. Store the data (**two locations -** a **Database and JSON file**)_

_o Database (can be either MS SQL or MongoDB - you choose)_

_o JSON file on the disk_

_Data: Sample File: [https://goo.gl/tJWo1f](https://goo.gl/tJWo1f)_

_Criteria: Your implementation properly follows all SOLID principles._

_Submitted Task Branch : SubmittedTask


# Solution

1- ASP.NET Core 3.1 API to upload the files

2-.NET Core 3.1 console application + Hangfire + Topshelf to process the files in the background or on a seperate server 

## Main Inspirations

1- [Adaptive Code: Agile coding with design patterns and SOLID principles (2nd Edition) (Developer Best Practices)](https://www.amazon.com/Adaptive-Code-principles-Developer-Practices/dp/1509302581) Chapter (11) - Stairway Pattern

2-  [Avoid Referencing Infrastructure in Visual Studio Solutions](https://ardalis.com/avoid-referencing-infrastructure-in-visual-studio-solutions)

3- [Modular Monolith with DDD](https://github.com/kgrzybek/modular-monolith-with-ddd)

4- [Dependency Injection Principles, Practices, and Patterns](https://www.manning.com/books/dependency-injection-principles-practices-patterns)

5- [Domain-Driven-Design-Example C#](https://github.com/zkavtaskin/Domain-Driven-Design-Example)

## Tools

-  ASP.NET Core 3.1
-  .NET Core 3.1
-  SQL Server
-  Autofac
-  Hangfire
-  Topshelf (Could have been replaced with  [service worker](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio) )
- [TinyCsvParser](http://bytefish.github.io/TinyCsvParser/index.html) (choosed based on this [Link](https://dotnetcoretutorials.com/2018/08/04/csv-parsing-in-net-core/))
- Distributed Caching (In-memory)


## Possible Enhancements

- Write Unit Tests 
- Eliminate SRP Violations
- Reconsider Database Context lifetime in Hangefire application 
- Reconsider Serializable attribute on domain models
- Docker (Compose)
- Enhance Dynamic Assembly loading
- Finish Caching Save Decorator
- TinyCsvParser parallel Processing
- Parallel Processing 
-  Review Naming Conventions
- Add Redis as caching server and as message queue
- Remove Hangfire and go completely Event Driven (consider [outbox](http://www.kamilgrzybek.com/design/the-outbox-pattern/) )
- Save files to azure using azure storage
## How to Run
> **Note:* Admin* Privilege is required (to save files)

1- Run `Update-Database` using project: **IReckonu.DataImportingTool.Data.SqlServer** while using **IReckonu.DataImportingTool.ProcessingApplication** as your startup project (will fails if API project is the startup project due to dynamic assembly loading)

2- Run **IReckonu.DataImportingTool.ProcessingApplication**

3- Run **IReckonu.DataImportingTool.API**
