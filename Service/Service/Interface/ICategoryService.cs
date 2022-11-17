using Service.DTOs.Book;
using Service.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interface
{
    public interface ICategoryService
    {

        Task CreateAsync(CategoryCreateAndUpdateDto category);
        Task<List<CategoryListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, CategoryCreateAndUpdateDto category);
        Task<List<CategoryListDto>> SearchAsync(string? searchText);

    }
}
