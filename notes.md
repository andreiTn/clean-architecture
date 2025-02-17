# Repository pattern

Advantages
- Easier unit testing
- Focus on the business (the DB is an implementation detail and it should be easy to switch DB providers without affecting the business logic)


To achieve this decoupling, the interface is defined in the application layer and the implementation is defined in the persistence/infrastructure layer. The model is defined in the Domain layer.

```c#
// App.Application - business logic
public ISubscriptionRepositroy { ... };

// App.Infrastructure - CRUD stuff
public class SubscriptionRepository { ... };
```

### Worfklow
- Request comes in the Presentation layer (user input)
- Call some handler in the Application layer (business logic)
- The DB updates are done in the Infrastructure layer (persistence)


# The unit of work pattern

Code example
```c#
/// ... some code

await _userRepository.UpdateUserAsync(user);
await _permissionsRepository.UpdateUserPermissionsAsync(user);

/// return something;
```

If for some reason one of the calls fails, we'll end up with inconsistent/broken data in our DB.

The UOW pattern, runs the calls in a transaction and makes sure all the changes either fail or succeed.
```c#
/// ... some code
private readonly IUnitOfWork _unitOfWork;
/// ... inject in the constructor

await _userRepository.UpdateUserAsync(user);
await _permissionsRepository.UpdateUserPermissionsAsync(user);
await _unitOfWork.CommitChangesAsync();
/// return something;
```

### Useful commands

Update ef
`dotnet tool update --global dotnet-ef`

Create migrations
`dotnet ef migrations add <MigrationName> -p /path/to/project/that/contains/the/db-context -s /path/to/project/that/contains/the/ef-design/package` (the infrastructure layer contains the DB context and the migrations and the presentation layer has the EF Core Design package)

Then  you need to update the db
`dotnet ef database update -p <db-context-project> -s <api-project>`
