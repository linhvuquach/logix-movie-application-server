# N-tier
An N-tier architecture divides an application into **logical layers** and **physical tiers**.

Layers are a way to separate responsibilities and manage dependencies. Each layer has a specific responsibility. A higher layer can use services in a lower layer, but not the other way around.

Tiers are physically separated, running on separate machines. A tier can call to another tier directly, or use asynchronous messaging (message queue). Although each layer might be hosted in its own tier, that's not required. Several layers might be hosted on the same tier. Physically separating the tiers improves scalability and resiliency, but also adds latency from the additional network communication.

## Folder structure
```
MyApiSolution/
├── MyApi.Web/
│   ├── Controllers/
│   │   ├── MovieController.cs
│   ├── Extentions/
│   │   ├── AppExtension.cs
│   │   ├── Policies.cs
│   ├── Startup.cs
│   └── ...
├── MyApi.Application/
│   ├── Services/
│   │   ├── Interfaces
│   │    ├── IMovieService.cs
│   │   ├── MovieService.cs
│   ├── Dtos/
│   │   ├── MovieDto.cs
│   └── ...
├── MyApi.Domain/
│   ├── Entities/
│   │   ├── Movie.cs
│   ├── Repositories/
│   │   ├── IMovieRepository.cs
│   └── ...
├── MyApi.Infrastructure/
│   ├── Data/
│   │   ├── ApplicationDbContext.cs
│   ├── Repositories/
│   │   ├── MovieRepository.cs
│   ├── Extentions/
│   │   ├── ModelBuilderExtensions.cs
│   └── ...
└── MyApi.Tests/
    ├── MyApi.UnitTests/
    ├── MyApi.IntegrationTests/
    └── ...
```

## References
- https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/n-tier