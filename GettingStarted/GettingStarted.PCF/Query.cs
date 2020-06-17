using System.Linq;
using GettingStarted.PCF.Data;
using GettingStarted.PCF.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GettingStarted.PCF
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] BooksContext context) => context.Books;
        public IQueryable<Author> GetAuthors([Service] BooksContext context) => context.Authors;
    }
}
