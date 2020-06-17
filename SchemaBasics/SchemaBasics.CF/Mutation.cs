using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using SchemaBasics.CF.Data;
using SchemaBasics.CF.Models;

namespace SchemaBasics.CF
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

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(x => x.CreateAuthorWithArgumentDescription(default, default))
                .Type<AuthorType>().Argument("authorAndBook",
                    argumentDescriptor =>
                        argumentDescriptor.Description("Argument description: Author with a book description"));
        }
    }

    public class AuthorAndBook
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }

    public class AuthorAndBookInputType : InputObjectType<AuthorAndBook>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AuthorAndBook> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Description("Type description: Input type for adding both author and his book.");
            descriptor.Field(x => x.Title).Description("Field description: Title of a book");
            descriptor.Field(x => x.AuthorName).Description("Field description: Author's name");
        }
    }
}