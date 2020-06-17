using System;
using System.IO;
using System.Threading.Tasks;
using GettingStarted.PCF;
using GettingStarted.PCF.Data;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;
using Xunit;

namespace GettingStarted.Tests.PCF
{
    public class GettingStartedTests
    {
        [Fact]
        public async Task Ensure_Schema_IsCorrect()
        {
            ISchema schema = SchemaBuilder.New().AddQueryType<Query>()
                .Create();

            string schemaSDL = schema.ToString();

            schemaSDL.MatchSnapshot();
        }

        [Fact]
        public async Task GetAuthors_AuthorsAreReturned()
        {
            IServiceProvider serviceProvider =
                new ServiceCollection()
                    .AddDbContext<BooksContext>(options =>
                        options.UseInMemoryDatabase(databaseName: "Books")
                            .UseLazyLoadingProxies())
                    .BuildServiceProvider();

            await serviceProvider.GetService<BooksContext>().Database.EnsureCreatedAsync();
            
            var fileName = "./.Queries/GetAuthors.graphql";
            var query = await File.ReadAllTextAsync($@"{Directory.GetCurrentDirectory()}/{fileName}");

            IQueryExecutor executor = SchemaBuilder.New()
                .AddQueryType<Query>()
                .Create()
                .MakeExecutable();

            IReadOnlyQueryRequest request =
                QueryRequestBuilder.New()
                    .SetQuery(query)
                    .SetServices(serviceProvider)
                    .Create();
            
            IExecutionResult result = await executor
                .ExecuteAsync(request);

            result.MatchSnapshot();
        }
    }
}