using System.Linq;
using HotChocolate;
using SchemaBasics.PCF.Data;
using SchemaBasics.PCF.Models;

namespace SchemaBasics.PCF
{
    public class Query
    {
        public IQueryable<Book> GetBooks([Service] BooksContext context) => context.Books;
        public IQueryable<Author> GetAuthors([Service] BooksContext context) => context.Authors;
    }
}
