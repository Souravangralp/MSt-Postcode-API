# MSt-Postcode-API

## Setup
1. Once code cloned. Please change the connection string in appsettings.json. Replace server name with your local MSSQL server name.
2. Run the project and it will create the database automatically. We don't need to run the migrations manually.

## Clean Architecture Overview

## Technologies
1. Web API using<a href="https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0">ASP.NET Core 8</a>
2. Data access with<a href="https://learn.microsoft.com/en-us/ef/core/">Entity Framework Core 8</a>
3. CQRS with<a href="https://github.com/jbogard/MediatR">MediatR</a>
4. Object-Object Mapping with<a href="https://automapper.org/">AutoMapper</a>
5. Validation with<a href="https://fluentvalidation.net/">FluentValidation</a>
6. Testing with<a href="https://nunit.org/">NUnit</a>, <a href="https://fluentassertions.com/">FluentAssertions</a>, <a href="https://github.com/moq">Moq</a> & <a href="https://github.com/jbogard/Respawn">Respawn</a>

# Overview

## Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

## Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

## Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

## Testing
We are using <a href="https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit">Nunit</a> for testing.
NUnit is a popular open-source unit testing framework for .NET applications, including those written in C#. A test case in NUnit is a method that tests a specific unit of code in isolation, typically a single method or function.
A typical NUnit test case will contain the following components:
- Naming the method :- MethodBeingTested_WhatSitutation_ExpectedResults
- Arrange :- Arrange the necessary context for the test. This might involve creating objects, initializing variables, and configuring the environment.
- Act :- This could be calling a method, invoking a function, or any other operation that you want to test.
- Assert :- After the action is performed, you use assertions to verify the expected behavior or outcomes of the action. You compare the actual results with the expected results and check if they match
- Using <a href="https://www.c-sharpcorner.com/UploadFile/75a48f/how-to-access-private-method-outside-the-class-in-C-Sharp/">reflection</a> technique to invoke Private methods for testing.
- How to wrtie test case :- <a href="https://app.pluralsight.com/course-player?clipId=91c53e48-ed50-4a8f-83f4-9d965264d83e">Learn here!</a>

## Code smells
• Methods > 30 lines. So your method shouldn't be more than 30 lines.
• Classes > 200 lines. So your classes should not be more than 200 lines. Create new small classes if needed.
• Anytime you scroll down, up, down to find what you’re looking for
• Regions
• You probably should’ve added a new class or method instead

## How to Add a new Table
How to create new API Endpoint
1. Add an Entity in Domain -> Entities -> New Table. (Make it signular migration will make it plural. Application is good class name but Applications isn't)
2. Add DBSET in interface Application -> Common -> Interfaces -> IApplicationDbContext (Make sure spacings is good as it is easy for readability)
3. Add implementation in Infrastructure -> Persistence -> ApplicationDbContext (Make sure spacings is good)
4. Under Application -> Add new folder Applications (if new entity name is Application)
5. Under Applications folder add -> Commands folder -> CreateApplication folder -> CreateApplicationCommand + CreateApplicationCommandValidator. We have to check all validations here. Including the ACN, APN number valid or not.
6. Under Applications folder add -> EventHandlers folder -> CreateApplication folder -> CreateApplicationCommand + CreateApplicationCommandValidator. We have to check all validations here. Including the ACN, APN number valid or not.
7. Under Domain -> Events -> Add ApplicationCreatedEvent, ApplicationDeletedEvent, ApplicationCompletedEvent or more we can add.
8. Under Applications folder add -> Queries -> GetApplicaitonsWithPagination + Dto + Validation
9. Under Infrastructure -> Persistence -> Add folder for configuration -> Add class for entity
10. Under WebUI -> Controllers -> Add ApplicationsController.
11. WRite down the test cases in the tests project. Already created for LoanApplication
11. Click on Tools -> NuGet Package Manager -> dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations

## Seeding
We are seeding data to Sql on build time, If any exception occured during the process, Do remove all the table data using the command we use during deployment. once done please run the project. issue could get resolved. below are some of the possible reasons why issues like above will occured.
1. Relations beetwen Entities are not configured correctly. (parent-child) 
2. Seeding null values to the required columns inside database during seeding process.
3. Sql server connection time-out during the transaction.
4. The data we are seeding is not correct.
