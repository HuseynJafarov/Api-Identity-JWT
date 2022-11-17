using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interface;
using Service.DTOs.Category;
using Service.DTOs.Product;
using Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateAndUpdateDto category)
        {
            await _repo.Create(_mapper.Map<Category>(category));

        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repo.Get(id);
            await _repo.Delete(category);
        }

        public async Task<List<CategoryListDto>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryListDto>>(await _repo.GetAll());
        }

        public async Task<List<CategoryListDto>> SearchAsync(string? searchText)
        {
            List<Category> searchDatas = new();
            if (searchText != null)
            {
                searchDatas = await _repo.FindAllAsync(m => m.Name.Contains(searchText));
            }
            else
            {
                searchDatas = await _repo.GetAll();
            }


            return _mapper.Map<List<CategoryListDto>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repo.Get(id);
            await _repo.SoftDelete(category);
        }

        public async Task UpdateAsync(int id, CategoryCreateAndUpdateDto category)
        {
            var dbCategory = await _repo.Get(id);
            _mapper.Map(category, dbCategory);
            await _repo.Update(dbCategory);
        }
    }
}
