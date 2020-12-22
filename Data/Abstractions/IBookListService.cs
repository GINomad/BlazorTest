using BlazorTest.Data.Models;
using System;
using System.Collections.Generic;

namespace BlazorTest.Data.Abstractions
{
    public interface IBookListService
    {
        IEnumerable<Book> Get();
        Book Get(Guid id);
        Guid Add(Book book);
        void Update(Book book);
    }
}
