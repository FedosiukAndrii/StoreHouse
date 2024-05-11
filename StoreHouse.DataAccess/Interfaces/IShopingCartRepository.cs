using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Interfaces
{
    public interface IShopingCartRepository : IRepository<CartItem>
    {
        public IQueryable<CartItem> CartItems { get; }
        public Task Update(CartItem cartItem);
    }
}