using System.Collections.Generic;
using HotChocolate.Types;

namespace UnionsAndInterfaces.CF.Models
{
    public abstract class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
    }

    public class TextBook : Book
    {
        public virtual ICollection<Class> Classes { get; set; }
    }

    public class ColoringBook : Book
    {
        public virtual ICollection<Color> Colors { get; set; }
    }

    public class BookType : InterfaceType<Book>
    {
        protected override void Configure(IInterfaceTypeDescriptor<Book> descriptor)
        {
            base.Configure(descriptor);
        }
    }

    public class ColoringBookType : ObjectType<ColoringBook>
    {
        protected override void Configure(IObjectTypeDescriptor<ColoringBook> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Implements<BookType>();
        }
    }

    public class TextBookType : ObjectType<TextBook>
    {
        protected override void Configure(IObjectTypeDescriptor<TextBook> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Implements<BookType>();
        }
    }

    public class Color
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}