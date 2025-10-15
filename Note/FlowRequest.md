[Client Request]
       |
       v
┌────────────────────────────┐
│   Middleware Pipeline      │
│ ┌────────────────────────┐ │
│ │ ExceptionHandlingMW    │ │ ← bắt lỗi toàn cục
│ └────────────────────────┘ │
│ ┌────────────────────────┐ │
│ │ RequestLoggingMW       │ │ ← log mọi request/response
│ └────────────────────────┘ │
└────────────┬───────────────┘
             v
     [Routing / Endpoint]
             |
             v
┌────────────────────────────┐
│    Controller (Area)       │ ← resolve qua DI
│  (vd: ProductController)   │
└────────────┬───────────────┘
             v
┌────────────────────────────┐
│       Service Layer        │ ← IProductService, BookingService, ...
│ (Xử lý logic nghiệp vụ)    │
└────────────┬───────────────┘
             v
┌────────────────────────────┐
│   Repository / DbContext   │ ← IGenericRepository, MyAppDbContext
│ (Tương tác DB thực tế)    │
└────────────┬───────────────┘
             v
       [Database / External]

[Client Request]
       |
       v
┌────────────────────────────┐
│   Middleware Pipeline      │
│ ┌────────────────────────┐ │
│ │ ExceptionHandlingMW    │ │ ← bắt lỗi toàn cục
│ └────────────────────────┘ │
│ ┌────────────────────────┐ │
│ │ RequestLoggingMW       │ │ ← log mọi request/response
│ └────────────────────────┘ │
└────────────┬───────────────┘
             v
     [Routing / Endpoint]
             |
             v
┌────────────────────────────┐
│    Controller (Area)       │ ← resolve qua DI
│  (vd: ProductController)   │
└────────────┬───────────────┘
             v
┌────────────────────────────┐
│       Service Layer        │ ← IProductService, BookingService, ...
│ (Xử lý logic nghiệp vụ)    │
└────────────┬───────────────┘
             v
┌────────────────────────────┐
│   Repository / DbContext   │ ← IGenericRepository, MyAppDbContext
│ (Tương tác DB thực tế)    │
└────────────┬───────────────┘
             v
       [Database / External]
