using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository = new();

        public async Task<List<Product>> GetAllAsync()
            => await _productRepository.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id)
            => await _productRepository.GetByIdAsync(id);

        public async Task<List<Product>> GetWithCategoryAsync()
            => await _productRepository.GetProductsWithCategoryAsync();

        public async Task<Product?> GetByIdWithCategoryAsync(int id)
            => await _productRepository.GetByIdWithCategoryAsync(id);

        public async Task AddAsync(Product product)
            => await _productRepository.AddProductAsync(product);

        public async Task UpdateAsync(Product product)
            => await _productRepository.UpdateProductAsync(product);

        public async Task DeleteAsync(Product product)
            => await _productRepository.RemoveProductAsync(product);
    }
}
