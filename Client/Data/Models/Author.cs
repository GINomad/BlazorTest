using System;

namespace BlazorTest.Data.Models
{
    public class Author: ICloneable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return new Author { Id = this.Id, Name = this.Name };
        }
    }
}
