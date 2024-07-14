using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Data
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<SubCategory> GetByIdAsync(int id);
        Task AddAsync(SubCategory subCategory);
        Task UpdateAsync(SubCategory subCategory);
        Task DeleteAsync(int id);

    }
}
