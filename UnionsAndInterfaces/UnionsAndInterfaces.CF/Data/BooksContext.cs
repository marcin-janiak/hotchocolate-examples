using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UnionsAndInterfaces.CF.Models;

namespace UnionsAndInterfaces.CF.Data
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TextBook>().HasData(new List<Book>()
            {
                new TextBook() {AuthorId = 1, Id = 1, Title = "Basic math"},
            });

            
            modelBuilder.Entity<ColoringBook>().HasData(new List<Book>()
            {
                new ColoringBook()
                {
                    AuthorId = 2, Id = 2, Title = "We don't make mistakes, just happy little accidents.",
                },
            });


            modelBuilder.Entity<Author>()
                .HasData(new List<Author>()
                {
                    new Author() {Id = 1, Name = "Some mathematician",},
                    new Author() {Id = 2, Name = "Bob Ross",}
                });
            
        }
    }
}