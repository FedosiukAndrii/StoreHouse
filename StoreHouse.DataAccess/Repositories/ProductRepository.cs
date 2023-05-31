using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Products => _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.Color)
                .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.Images);

        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products
                .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.Color)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task Update(Product product)
        {
            Product existingProduct = await _dbContext.Products
                .Include(p => p.ProductColors)
                .SingleOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ProductColors = product.ProductColors;

                _dbContext.Products.Update(existingProduct);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
