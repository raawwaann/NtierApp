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
        private readonly ICategoryService _categoryService;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, ICategoryService categoryService)
        {
            _subcategoryRepository = subCategoryRepository;
            _categoryService = categoryService;
        }
        public async Task AddAsync(SubCategoryDto subCatgeoryDto)
        {
            // Validate if the subcategory is allowed for the given category
            if (await _categoryService.IsSubCategoryAllowedAsync(subCatgeoryDto.CategoryId, subCatgeoryDto.Name))
            {
                var subCategory = new SubCategory
                {
                    Name = subCatgeoryDto.Name,
                    Description = subCatgeoryDto.Description,
                    CategoryId = subCatgeoryDto.CategoryId
                };

                await _subcategoryRepository.AddAsync(subCategory);
            }
            else
            {
                throw new ArgumentException("Subcategory is not allowed for the selected category.");
            }
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
               
            };
        }

        public async Task UpdateAsync(SubCategoryDto subCatgeoryDto)
        {
            // Validate if the subcategory is allowed for the given category
            if (await _categoryService.IsSubCategoryAllowedAsync(subCatgeoryDto.CategoryId, subCatgeoryDto.Name))
            {
                var subCategory = await _subcategoryRepository.GetByIdAsync(subCatgeoryDto.Id);
                if (subCategory == null) return;

                subCategory.Name = subCatgeoryDto.Name;
                subCategory.Description = subCatgeoryDto.Description;
                subCategory.CategoryId = subCatgeoryDto.CategoryId;

                await _subcategoryRepository.UpdateAsync(subCategory);
            }
            else
            {
                throw new ArgumentException("Subcategory is not allowed for the selected category.");
            }
        }
    }
}
