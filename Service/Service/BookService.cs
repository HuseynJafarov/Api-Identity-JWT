using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interface;
using Service.DTOs.Book;
using Service.DTOs.Product;
using Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateAndUpdateDto book)
        {
            await _repo.Create(_mapper.Map<Book>(book));
        }

        public async Task DeleteAsync(int id)
        {
            Book book = await _repo.Get(id);
            await _repo.Delete(book);

        }

        public async Task<List<BookListDto>> GetAllAsync()
        {
            return _mapper.Map<List<BookListDto>>(await _repo.GetAll());
        }

        public async Task<List<BookListDto>> SearchAsync(string? searchText)
        {
            List<Book> searchDatas = new();
            if (searchText != null)
            {
                searchDatas = await _repo.FindAllAsync(m => m.Name.Contains(searchText) && m.Author.Contains(searchText));
            }
            else
            {
                searchDatas = await _repo.GetAll();
            }


            return _mapper.Map<List<BookListDto>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            Book book = await _repo.Get(id);
            await _repo.SoftDelete(book);
        }

        public async Task UpdateAsync(int id, BookCreateAndUpdateDto book)
        {
            var dbBook = await _repo.Get(id);
            _mapper.Map(book, dbBook);
            await _repo.Update(dbBook);
        }
    }
}

