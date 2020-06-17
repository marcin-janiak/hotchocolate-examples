using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchemaBasics.CF.Data;
using SchemaBasics.CF.Models;

namespace SchemaBasics.CF
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
                    .UseLazyLoadingProxies(), ServiceLifetime.Transient);

            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
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