using Paddys.SupermarketCheckout.Services.Services.Products.Data.Models;

namespace Paddys.SupermarketCheckout.Services.Services.Products.Data
{
    public interface IProductCommands
    {
        void InsertProduct(ProductEntity productEntity);
        void UpdateProduct(ProductEntity productEntity);
        void DeleteProduct(int id);
    }
}
