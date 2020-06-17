using System.Threading.Tasks;
using HotChocolate;
using Snapshooter.Xunit;
using Xunit;

namespace GettingStarted.PCF.Tests
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
    }
}