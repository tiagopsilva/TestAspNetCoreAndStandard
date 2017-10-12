using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAspNet.Domain.Commands.Handlers;
using TestAspNet.Domain.Contexts;
using TestAspNet.Domain.Repositories;
using TestAspNet.Domain.Services;

namespace TestAspNet.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];

            services.AddScoped<EntityContext>(service => new EntityContext(connectionString));

            services.AddTransient<CustomerRepository>();

            services.AddTransient<CustomerService>();

            services.AddTransient<CustomerCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
