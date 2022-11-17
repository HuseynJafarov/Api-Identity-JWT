using Domain.Entities;
using Service.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Interface
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto product);
        Task<List<ProductListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync (int id,ProductUpdateDto product);
        Task<List<ProductListDto>> SearchAsync(string? searchText);

    }
}
