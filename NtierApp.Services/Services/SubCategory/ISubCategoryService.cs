using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDto>> GetAllAsync();
        Task<SubCategoryDto> GetByIdAsync(int id);
        Task AddAsync(SubCategoryDto subCatgeoryDto);
        Task UpdateAsync(SubCategoryDto subCatgeoryDto);
        Task DeleteAsync(int id);
    }
}
