using BlazorTest.Data.Abstractions;
using BlazorTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorTest.Data
{
    public class BookListService : IBookListService
    {
        private static IList<Book> _inMemoryStorage;
        
        public BookListService()
        {
            _inMemoryStorage = new List<Book>()
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Description = "Test Description for the first book.",
                    Name = "Test Book #1",
                    PublishDate = DateTime.UtcNow,
                    Author = new Author
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Author #1"
                    }
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Description = "Test Description for the second book.",
                    Name = "Test Book #2",
                    PublishDate = DateTime.UtcNow,
                    Author = new Author
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Author #2"
                    }
                }
            };

            foreach(var book in _inMemoryStorage)
            {
                book.AuthorId = book.Author.Id.ToString();
            }
        }

        public Guid Add(Book book)
        {
            book.Id = Guid.NewGuid();
            _inMemoryStorage.Add(book);

            return book.Id;
        }

        public IEnumerable<Book> Get()
        {
            return _inMemoryStorage;
        }

        public Book Get(Guid id)
        {
            return _inMemoryStorage.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Book book)
        {
            var bookForUpdate = _inMemoryStorage.FirstOrDefault(b => b.Id == book.Id);
            if(bookForUpdate == null)
            {
                throw new InvalidOperationException("The book is not found.");
            }

            bookForUpdate.Name = book.Name;
            bookForUpdate.PublishDate = book.PublishDate;
            bookForUpdate.Description = book.Description;
        }
    }
}
