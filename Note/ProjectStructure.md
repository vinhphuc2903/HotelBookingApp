/MyApp
├── Areas
│   ├── Admin
│   │   ├── Controllers
│   │   │   └── ProductController.cs
│   │   ├── Models
│   │   │   └── ProductDto.cs
│   │   └── Services
│   │       ├── IProductService.cs
│   │       └── ProductService.cs
│   └── Customer
│       ├── Controllers
│       │   └── BookingController.cs
│       ├── Models
│       │   └── BookingDto.cs
│       └── Services
│           ├── IBookingService.cs
│           └── BookingService.cs
├── Controllers
│   └── HomeController.cs
├── Core
│   ├── Interfaces
│   └── Entities
├── Infrastructure
│   ├── Data
│   │   └── MyAppDbContext.cs
│   └── Repositories
│       ├── IGenericRepository.cs
│       └── GenericRepository.cs
├── Middleware
│   ├── RequestLoggingMiddleware.cs
│   └── ExceptionHandlingMiddleware.cs
├── Program.cs
├── appsettings.json
└── AutofacModules
    └── ServiceModule.cs
