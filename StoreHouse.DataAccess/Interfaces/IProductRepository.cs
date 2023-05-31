using StoreHouse.Models.Entities;
namespace StoreHouse.DataAccess.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    public IQueryable<Product> Products {get;}
    public Task Update(Product product);
}
