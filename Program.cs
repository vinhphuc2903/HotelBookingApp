using Microsoft.EntityFrameworkCore;
using MiniShopBE.Data;
using MiniShopBE.Areas.Products.AutofacModules;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// 1. Cấu hình DB Context
// ==========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ==========================
// 2. Thêm Controllers và Areas
// Thêm các service vào DI container
// builder.Services là một đối tượng IServiceCollection, nơi bạn đăng ký các dịch vụ mà ứng dụng của bạn sẽ sử dụng. Đây là nơi bạn cấu hình DI.
// Phương thức này đăng ký các dịch vụ cần thiết để hỗ trợ các controller và view trong ứng dụng MVC. Khi bạn gọi phương thức này, ASP.NET Core sẽ tự động tiêm các phụ thuộc cần thiết cho các controller của bạn.
// Tương tự, phương thức này đăng ký các dịch vụ cần thiết cho Razor Pages, cho phép bạn sử dụng các page trong ứng dụng.
// Hai phương thức này đăng ký các dịch vụ cần thiết để tạo tài liệu API với Swagger. Swagger cũng sử dụng DI để tiêm các phụ thuộc cần thiết cho việc tạo ra tài liệu API.
// ==========================
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // nếu có dùng Razor Pages

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ServiceModule());
});

// Cấu hình Swagger nếu cần
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ==========================
// 3. Middleware Pipeline
// ==========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// ==========================
// 4. Đăng ký Route cho Areas
// ==========================
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
