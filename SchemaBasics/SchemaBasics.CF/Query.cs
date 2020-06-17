using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SchemaBasics.CF.Data;
using SchemaBasics.CF.Models;

namespace SchemaBasics.CF
{
    public class Query
    {
        public IQueryable<Book> GetBooks([Service] BooksContext context) => context.Books;
        public IQueryable<Author> GetAuthors([Service] BooksContext context) => context.Authors;
    }

    public class QueryType : ObjectType<Query>
    {
    }
}
