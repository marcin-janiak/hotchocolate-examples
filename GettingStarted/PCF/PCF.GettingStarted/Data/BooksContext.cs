using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PCF.GettingStarted.Models;

namespace PCF.GettingStarted.Data
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

            modelBuilder.Entity<Book>().HasData(new List<Book>()
            {
                new Book() {AuthorId = 1, Id = 1, Title = "The Last Wish"},
                new Book() {AuthorId = 1, Id = 2, Title = "Sword of Destiny"},
                new Book() {AuthorId = 1, Id = 3, Title = "Blood of Elves"},
                new Book() {AuthorId = 1, Id = 4, Title = "Time of Contempt"},
                new Book() {AuthorId = 1, Id = 5, Title = "Baptism of Fire"},
                new Book() {AuthorId = 1, Id = 6, Title = "The Tower of the Swallow"},
                new Book() {AuthorId = 1, Id = 7, Title = "The Lady of the Lake"},
                new Book() {AuthorId = 1, Id = 8, Title = "Season of Storms"},
                new Book() {AuthorId = 2, Id = 9, Title = "It"},
                new Book() {AuthorId = 2, Id = 10, Title = "The Shining"},
                new Book() {AuthorId = 2, Id = 11, Title = "The Stand"},
                new Book() {AuthorId = 2, Id = 12, Title = "The Outsider"},
                new Book() {AuthorId = 2, Id = 13, Title = "Misery"},
            });

            modelBuilder.Entity<Author>()
                .HasData(new List<Author>()
                {
                    new Author() {Id = 1, FirstName = "Andrzej", LastName = "Sapkowski",},
                    new Author() {Id = 2, FirstName = "Stephen", LastName = "King",}
                });
        }
    }
}
