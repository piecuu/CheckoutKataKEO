using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Interfaces
{
    public interface IProductCatalog
    {
        Product GetProduct(string sku);
    }
}