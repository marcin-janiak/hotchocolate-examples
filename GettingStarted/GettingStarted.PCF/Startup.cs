using GettingStarted.PCF.Data;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GettingStarted.PCF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BooksContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Books")
                    .UseLazyLoadingProxies());

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddQueryType<Query>()
                .Create());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BooksContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseGraphQL()
                .UsePlayground();

            context.Database.EnsureCreated();
        }
    }
}