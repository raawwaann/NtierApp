using NtierApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subcategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subcategoryRepository = subCategoryRepository;
        }
        public async Task AddAsync(SubCategoryDto subCatgeoryDto)
        {
            var subcategories = new SubCategory
            {
                Name = subCatgeoryDto.Name,
                Description=subCatgeoryDto.Description,
                 CategoryId = subCatgeoryDto.CategoryId,
          
            };
            await _subcategoryRepository.AddAsync(subcategories);   
        }

        public async Task DeleteAsync(int id)
        {
            await _subcategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllAsync()
        {
            var subcategories=await _subcategoryRepository.GetAllAsync();
            return subcategories.Select(c => new SubCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description=c.Description,
                 CategoryId = c.CategoryId,
                Category = c.Category

            });
           
        }

        public async Task<SubCategoryDto> GetByIdAsync(int id)
        {
            var subcategories = await _subcategoryRepository.GetByIdAsync(id);
            if (subcategories == null) return null;
            return new SubCategoryDto
            {
                Id= subcategories.Id,
                Name = subcategories.Name,
                Description = subcategories.Description,
                CategoryId=subcategories.CategoryId,
                Category = subcategories.Category
            };
        }

        public async Task UpdateAsync(SubCategoryDto subCatgeoryDto)
        {
            var subcategories = await _subcategoryRepository.GetByIdAsync(subCatgeoryDto.Id);
            if (subcategories == null) return;

            subcategories.Name = subCatgeoryDto.Name;
            subcategories.Description= subCatgeoryDto.Description;
            subcategories.Category = subCatgeoryDto.Category;

            await _subcategoryRepository.UpdateAsync(subcategories);
        }
    }
}
