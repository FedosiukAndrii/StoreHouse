using AutoMapper;
using StoreHouse.Models.Entities;

namespace StoreHouse.Models.DTOs
{
    public class ProductListItemDto 
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
    }
}
