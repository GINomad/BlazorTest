using BlazorTest.Data.Abstractions;
using BlazorTest.Data.Models;
using Esquio.Abstractions;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorTest.Pages
{
    public partial class BookList : ComponentBase
    {
        [Inject]
        private IBookListService BookListService { get; set; }
        [Inject]
        private IFeatureService FeatureService { get; set; }
        private IEnumerable<Book> _books;
        
        public BookList()
        {            
        }

        public IEnumerable<Book> Books
        {
            get
            {
                return _books;
            }
        }
        public Book SelectedBook { get; private set; }
        public string ComponentSize { get { return SelectedBook == null ? "col-md-12" : "col-md-8"; } }

        public void OnEditClick(Book book)
        {
            SelectedBook = book;
        }

        public void Reload()
        {
            SelectedBook = null;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            _books = BookListService.Get();
            base.OnInitialized();
        }
    }
}
