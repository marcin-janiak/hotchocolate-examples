namespace SchemaBasics.SF
{
    public static class Constants
    {
        public static string Schema = @"
schema {
        query: Query
            mutation: Mutation
    }

    type Author {
    books: [Book]
    id: Int!
    name: String
    }

    type Book {
    author: Author
        authorId: Int!
    id: Int!
    title: String
    }

    type Mutation {
    addBook(authorId: Int! title: String): Book
        createAuthor(authorAndBook: AuthorAndBookInput): Author
        createAuthorWithArgumentDescription(""Argument description: Author with a book description"" authorAndBook: AuthorAndBookInput): Author
    }

    type Query {
    authors: [Author]
    books: [Book]
    }

    ""Type description: Input type for adding both author and his book.""
    input AuthorAndBookInput {
    ""Field description: Author's name""
    authorName: String
    ""Field description: Title of a book""
    title: String
    }
";
    }
}