# Clean architecture layers

## The Presentation layer
*What's presented to the outside world*

This layer is responsible for handling the user interactions the user interface depending on what we're building.

It takes the data that comes from the user and converts it to the representation that applicationis using.

- Should be able to evolve over time independently from the business logic and domain.
- Includes components like controllers, views and presenters

## The Application layer

Execute the application use cases - what actions can users to on our system.
- Fetch domain objects
- Manipulate domain objects

This layer contains the application specific business rules. It orchestrates the flow of data
to and from the entities and the presentation layer.

- Defines the operations that the application can perform
- Contains use cases or services that encapsulate business logic

## The Infrastructure layer
- Interacts with the persistence solution
- Interacts with other services (web clients, message brokers, etc.)
- Interaction with the underlying machine (system clock, files, etc.)
- Identity concerns

It provides the implementation for the interfaces defined in the other layers.

- Contains repositories, data mappers, and external service implementations
- Should be replaced without affecting other layers

## The Domain layer

This layer contains core business logic and rules. It's the heart of the application and should be independent of other layers.

- Includes entities and value objects
- Should not depend on any external libraries and frameworks
