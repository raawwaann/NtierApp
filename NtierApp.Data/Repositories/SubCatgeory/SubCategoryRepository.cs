using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Data
{

    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly NtierAppContext _context;
      

        public SubCategoryRepository(NtierAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            try
            {
                return await _context.SubCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<SubCategory>();
            }
        }
        public async Task AddAsync(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory != null)
            {
                _context.SubCategories.Remove(subCategory);
                await _context.SaveChangesAsync();
            }
        }

       
        public async Task<SubCategory> GetByIdAsync(int id)
        {
            return await _context.SubCategories.FindAsync(id);
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
        }
    }
}
