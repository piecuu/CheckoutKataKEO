using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Interfaces
{
    public interface IDiscountService
    {
        decimal ApplyProductDiscount(ProductLine productLine, Discount discount);
    }
}