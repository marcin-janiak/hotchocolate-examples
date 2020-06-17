using System.Collections.Generic;
using HotChocolate.Types;

namespace SchemaBasics.CF.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            base.Configure(descriptor);
        }
    }
}