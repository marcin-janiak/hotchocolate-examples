using System.Linq;
using HotChocolate;
using SchemaBasics.SF.Data;
using SchemaBasics.SF.Models;

namespace SchemaBasics.SF
{
    public class Query
    {
        public IQueryable<Book> GetBooks([Service] BooksContext context) => context.Books;
        public IQueryable<Author> GetAuthors([Service] BooksContext context) => context.Authors;
    }
}
