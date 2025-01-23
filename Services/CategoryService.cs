using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.ViewModels.Categorys;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategorys();
        Task<CategoryViewModel> GetCategory(int id);
        Task<Category> Create(CategoryRequest request);
        Task<bool> Update(int id, CategoryViewModel category);
        Task<bool> Delete(int id);
        bool CategoryExists(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categorys.Any(e => e.Id == id);
        }

        public async Task<Category> Create(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categorys.FindAsync(id);
            if (category != null)
            {
                _context.Categorys.Remove(category);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var category = await _context.Categorys
        //  .Include(c => c.Products) // Tải thêm danh sách sản phẩm liên quan
         .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategorys()
        {
            var categorys = await _context.Categorys.ToListAsync();// Tải thêm danh sách sản phẩm liên quan
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categorys);
        }

        public async Task<bool> Update(int id, CategoryViewModel category)
        {
            _context.Update(_mapper.Map<Category>(category));
            await _context.SaveChangesAsync();
            return true;
        }
    }
}