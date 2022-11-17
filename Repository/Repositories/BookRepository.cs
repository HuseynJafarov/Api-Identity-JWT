using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BookRepository : Repository<Book> , IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {

        }
    }
}
