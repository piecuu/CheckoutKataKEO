using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Interfaces
{
    public interface IDiscountCatalog
    {
        Discount? GetDiscount(string sku);
    }
}