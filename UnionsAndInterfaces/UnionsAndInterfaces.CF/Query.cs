using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using UnionsAndInterfaces.CF.Data;
using UnionsAndInterfaces.CF.Models;

namespace UnionsAndInterfaces.CF
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
