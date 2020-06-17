using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchemaBasics.SF.Data;
using SchemaBasics.SF.Models;

namespace SchemaBasics.SF
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

            services.AddGraphQL(sp => SchemaBuilder.New().AddDocumentFromString(Constants.Schema)
                .BindComplexType<Query>()
                .BindComplexType<Mutation>()
                .BindComplexType<Author>()
                .BindComplexType<Book>()
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