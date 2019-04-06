namespace David.SecondBook.OnlineStore.WebApp
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using David.SecondBook.OnlineStore.Domain.Abstract;
    using System;
    using System.Web.Mvc;

    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();


            // Create mock data by using Moq directly
            //         Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //         mock
            //             .Setup(m => m.ProductsList)
            //             .Returns(new List<Product>{
            //                 new Product { Name = "Football", Price = 25 },
            //		new Product { Name = "Surf board", Price = 179 },
            //		new Product { Name = "Running shoes", Price = 95 }
            //                 });
            //builder.RegisterInstance<IProductsRepository>(mock.Object);     

            // builder.RegisterInstance(new MockProductsRepository()).As<IProductsRepository>();
            builder.RegisterInstance<IProductsRepository>(new MockProductsRepository()).PropertiesAutowired();


            // Register your MVC controllers. 
            // (MvcApplication is the name of the class in Global.asax.)            
            // builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies()).PropertiesAutowired();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
