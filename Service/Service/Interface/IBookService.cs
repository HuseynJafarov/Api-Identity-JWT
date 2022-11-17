using Service.DTOs.Book;
using Service.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interface
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateAndUpdateDto book);
        Task<List<BookListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookCreateAndUpdateDto book);
        Task<List<BookListDto>> SearchAsync(string? searchText);
    }
}
