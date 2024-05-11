using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class ImageRepository : RepositoryBase<ProductColorImage>, IImageRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }

        public async Task AddRange(IEnumerable<ProductColorImage> images)
        {
            int productId = images.FirstOrDefault()?.ProductId ?? 0;

            var imagesToDelete = dbSet.Where(i => i.ProductId == productId && images.Select(newImages => newImages.ColorId).Contains(i.ColorId));
            dbSet.RemoveRange(imagesToDelete);

            await dbSet.AddRangeAsync(images);
            await _dbContex.SaveChangesAsync();
        }
    }
}
