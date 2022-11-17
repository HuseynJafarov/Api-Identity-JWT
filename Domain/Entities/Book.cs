using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
         
    }
}
