using System.Collections.Generic;
using HotChocolate;
using SchemaBasics.SF.Data;
using SchemaBasics.SF.Models;

namespace SchemaBasics.SF
{
    public class Mutation
    {
        public Book AddBook([Service] BooksContext context, string title, int authorId)
        {
            var book = new Book
            {
                AuthorId = authorId,
                Title = title
            };

            context.Books.Add(book);
            context.SaveChanges();

            return book;
        }

        public Author CreateAuthor([Service] BooksContext context, AuthorAndBook authorAndBook)
        {
            var author = new Author()
            {
                Name = authorAndBook.AuthorName,
                Books = new List<Book>
                {
                    new Book {Title = authorAndBook.Title}
                }
            };

            context.Authors.Add(author);
            context.SaveChanges();

            return author;
        }

        public Author CreateAuthorWithArgumentDescription([Service] BooksContext context,
            [GraphQLDescription("Argument description: Author with a book description")]
            AuthorAndBook authorAndBook)
        {
            var author = new Author()
            {
                Name = authorAndBook.AuthorName,
                Books = new List<Book>
                {
                    new Book {Title = authorAndBook.Title}
                }
            };

            context.Authors.Add(author);
            context.SaveChanges();

            return author;
        }
    }

    [GraphQLDescription("Type description: Input type for adding both author and his book.")]
    public class AuthorAndBook
    {
        [GraphQLDescription("Field description: Title of a book")]
        public string Title { get; set; }

        [GraphQLDescription("Field description: Author's name")] public string AuthorName { get; set; }
    }
}