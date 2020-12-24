using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTest.Data.Models
{
    public class Book: ICloneable
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public string Classification { get; set; }

        public Author Author { get; set; }

        public object Clone()
        {
            return new Book
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                PublishDate = this.PublishDate,
                AuthorId = this.AuthorId,
                Author = this.Author.Clone() as Author
            };
        }
    }
}
