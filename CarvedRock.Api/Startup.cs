using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductType = CarvedRock.Api.GraphQL.Types.ProductType;

namespace CarvedRock.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CarvedRockDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]));

            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();
            services.AddScoped<SellerRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CarvedRockSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = _env.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(context => context.User)
                .AddDataLoader();

            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, CarvedRockDbContext dbContext)
        {
            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.Seed();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Count().OrderBy().Filter();
            });
        }
    }
}