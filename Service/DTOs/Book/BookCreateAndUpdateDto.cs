using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Book
{
    public class BookCreateAndUpdateDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
