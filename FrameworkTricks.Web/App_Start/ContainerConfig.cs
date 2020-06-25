using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FrameworkTricks.Application.Services;
using FrameworkTricks.Web.Controllers;
using System.Web.Http;
using System.Web.Mvc;

namespace FrameworkTricks.Web.App_Start
{
    public class ContainerConfig
    {
        // HACK: Basic Autofac configuration for both MVC and WebApi
        public static void RegisterContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();

            builder.RegisterType<EmployeeData>().SingleInstance();

            builder.RegisterType<FrameworkTricksDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}