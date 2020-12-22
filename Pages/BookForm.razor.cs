using BlazorTest.Data.Abstractions;
using BlazorTest.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace BlazorTest.Pages
{
    public partial class BookForm: ComponentBase
    {
        [Inject]
        private IBookListService BookListService { get; set; }

        [Parameter]
        public Guid BookId { get; set; }

        public Book CurrentBook { get; set; }

        public void Update()
        {
            BookListService.Update(CurrentBook);
            if (OnSubmitCallback.HasDelegate)
            {
                OnSubmitCallback.InvokeAsync(null);
            }
        }

        [Parameter]
        public EventCallback<MouseEventArgs> OnCancelCallback { get; set; }
        [Parameter]
        public EventCallback OnSubmitCallback { get; set; }

        protected override void OnParametersSet()
        {
            CurrentBook = BookListService.Get(BookId)?.Clone() as Book;
            base.OnParametersSet();
        }
    }
}
