using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await AddAsync(category);
            await SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            Update(category);
            await SaveChangesAsync();
        }

        public async Task RemoveCategoryAsync(Category category)
        {
            Remove(category);
            await SaveChangesAsync();
        }
    }
}
