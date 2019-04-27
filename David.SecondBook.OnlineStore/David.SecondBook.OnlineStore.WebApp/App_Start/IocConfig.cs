namespace David.SecondBook.OnlineStore.WebApp
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using David.SecondBook.OnlineStore.Domain.Abstract;
    using David.SecondBook.OnlineStore.Domain.Concrete;
    using David.SecondBook.OnlineStore.Domain.Entities;
    using David.SecondBook.OnlineStore.WebApp.Abstract;
    using David.SecondBook.OnlineStore.WebApp.Concrete;
    using System;
    using System.Web.Mvc;

    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. 
            // (MvcApplication is the name of the class in Global.asax.)            
            // builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies()).PropertiesAutowired();


            // Create mock data by using Moq directly
            builder
                .RegisterType<EFDbContext>()
                .PropertiesAutowired();

            builder
                .RegisterType<EFDbProductsRepository>()
                .As<IProductsRepository>()
                .PropertiesAutowired();

            builder.RegisterType<EmailSettings>().AsSelf().PropertiesAutowired();

            builder
                .RegisterType<EmailOrderProcessor>()
                .As<IOrderProcessor>()
                .PropertiesAutowired();


            builder
                .RegisterType<DbAuthProvider>()
                .As<IAuthProvider>()
                .PropertiesAutowired();
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
