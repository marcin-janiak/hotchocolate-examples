using HotChocolate.Types;

namespace SchemaBasics.CF.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
    }
    
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            base.Configure(descriptor);
        }
    }

}