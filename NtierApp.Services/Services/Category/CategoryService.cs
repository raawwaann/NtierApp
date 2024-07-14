using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtierApp.Data;
namespace NtierApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var Categories = await _CategoryRepository.GetAllAsync();
            return Categories.Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                AllowedSubCategories = p.AllowedSubCategories
            });
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var Category = await _CategoryRepository.GetByIdAsync(id);
            if (Category == null) return null;

            return new CategoryDto
            {
                Id = Category.Id,
                Name = Category.Name,
                Description = Category.Description,
                AllowedSubCategories = Category.AllowedSubCategories

            };
        }

        public async Task AddAsync(CategoryDto CategoryDto)
        {
            var Category = new Category
            {
                Name = CategoryDto.Name,
                Description = CategoryDto.Description,
                AllowedSubCategories= CategoryDto.AllowedSubCategories
                
            };

            await _CategoryRepository.AddAsync(Category);
        }

        public async Task UpdateAsync(CategoryDto CategoryDto)
        {
            var Category = await _CategoryRepository.GetByIdAsync(CategoryDto.Id);
            if (Category == null) return;

            Category.Name = CategoryDto.Name;
            Category.Description = CategoryDto.Description;
            Category.AllowedSubCategories = CategoryDto.AllowedSubCategories;

            await _CategoryRepository.UpdateAsync(Category);
        }

        public async Task DeleteAsync(int id)
        {
            await _CategoryRepository.DeleteAsync(id);
        }
        public async Task<bool> IsSubCategoryAllowedAsync(int categoryId, string subCategoryName)
        {
            var category = await _CategoryRepository.GetByIdAsync(categoryId);
            return category != null && category.AllowedSubCategories.Contains(subCategoryName);
        }
    }
}

