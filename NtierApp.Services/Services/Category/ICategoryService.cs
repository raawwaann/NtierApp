using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryDto CategoryDto);
        Task UpdateAsync(CategoryDto CategoryDto);
        Task DeleteAsync(int id);
        Task<bool> IsSubCategoryAllowedAsync(int categoryId, string subCategoryName);
    }
}
