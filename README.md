# Clean Architecture Template.

The goal of this template is to provide a fast a structured way to create a new project using Net Core and the Clean architecture approach.

I hope you find this solution useful and give it an start ⭐

## Description.
The project follows the Clean architecture structure. It contains 4 basic layers.

- Domain (Entities)
- Application (Use Case)
- Infrastructure
- Api

### Domain Layer. (Innermost Layer).
These represent the core business objects of the application. They are the most fundamental and least likely to change.

Characteristics: Entities encapsulate the most general and high-level rules. They are pure data objects with minimal behavior. They don't depend on any other layers. They might have methods related to their data, but these methods should be essential to the entity's identity and purpose.

### Application Layer or Use Cases. (Business Logic Layer).
This layer contains the specific business rules or use cases of the application. It orchestrates the entities to perform actions.

Characteristics: Use cases describe the interactions between the user (or another system) and the core business logic. They define what the system does. They depend on the Entities layer but are independent of any infrastructure concerns.

### Api or Interface Adapters (Gateway Layer).
This layer acts as a bridge between the Use Cases and the outside world (databases, UIs, external services).

Characteristics: Adapters convert data from the format required by the Use Cases to the format used by the external systems and vice-versa. They translate data coming in from the UI or database into the data structures used by the Use Cases. They also translate the output of the Use Cases into a format suitable for the UI or database. This layer isolates the core business logic from changes in external technologies.

### Infrastructure Frameworks and Drivers (Outermost Layer).
This is the layer where all the external technologies reside: the UI, the database, web frameworks, etc.

Characteristics: This layer contains the code specific to the chosen frameworks and tools. It's the least stable layer because it's most susceptible to changes in technology.
Examples: Spring MVC, React, Angular, MySQL, MongoDB.

## Nuget Used for each layer

### Domain Layer.
ErrorOr - A simple, fluent discriminated union of an error or a result.
Library used to handling the Railway Oriented programming.
https://www.nuget.org/packages/ErrorOr

### Application Layer or Use Cases. (Business Logic Layer).
FluentValidation - A validation library for .NET that uses a fluent interface and lambda expressions for building strongly-typed validation rules
https://github.com/FluentValidation/FluentValidation

MidiatR - Simple, unambitious mediator implementation in .NET
https://www.nuget.org/packages/MediatR

ErrorOr - ErrorOr - A simple, fluent discriminated union of an error or a result.
Library used to handling the Railway Oriented programming.
https://www.nuget.org/packages/ErrorOr

### Api or Interface Adapters (Gateway Layer).
ErrorOr - ErrorOr - A simple, fluent discriminated union of an error or a result.
Library used to handling the Railway Oriented programming.
https://www.nuget.org/packages/ErrorOr

MidiatR - Simple, unambitious mediator implementation in .NET
https://www.nuget.org/packages/MediatR
