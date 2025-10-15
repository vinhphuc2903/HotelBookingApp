using Autofac;
using MiniShopBE.Areas.Products.Services;

namespace MiniShopBE.Areas.Products.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Đăng ký Service
            builder.RegisterType<ProductService>()
                   .As<IProductService>()
                   .InstancePerLifetimeScope();
        }
    }
}
