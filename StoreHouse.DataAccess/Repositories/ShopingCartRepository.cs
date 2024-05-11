using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class ShopingCartRepository : RepositoryBase<CartItem>, IShopingCartRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public ShopingCartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }

        public IQueryable<CartItem> CartItems => _dbContex.CartItems
            .Include(i => i.User)
            .Include(i=> i.Color)
            .Include(i=> i.Size)
            .Include(i => i.Product)
            .ThenInclude( i => i.ProductColors)
            .ThenInclude(i => i.Images)
			.Include(i => i.Product)
			.ThenInclude(i => i.ProductColors)
            .ThenInclude(i => i.Color);


		public async Task Update(CartItem cartItem)
        {
            _dbContex.Update(cartItem);

            await _dbContex.SaveChangesAsync();
        }
    }
}
