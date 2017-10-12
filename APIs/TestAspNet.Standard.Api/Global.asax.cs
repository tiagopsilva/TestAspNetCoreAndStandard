using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using TestAspNet.Domain.Commands.Handlers;
using TestAspNet.Domain.Contexts;
using TestAspNet.Domain.Repositories;
using TestAspNet.Domain.Services;

namespace TestAspNet.Standard.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<EntityContext>(() => new EntityContext(), Lifestyle.Scoped);

            container.Register<CustomerRepository>(Lifestyle.Transient);

            container.Register<CustomerService>(Lifestyle.Transient);

            container.Register<CustomerCommandHandler>(Lifestyle.Transient);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
