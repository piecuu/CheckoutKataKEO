using CheckoutKataKEO.Core.Interfaces;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Services
{
    public class DiscountService : IDiscountService
    {
        public DiscountService()
        {
        }

        public decimal ApplyProductDiscount(ProductLine productLine, Discount discount)
        {
            var totalCost = 0.0m;
            var quantity = productLine.Quantity;
            var productPrice = productLine.Product.Price;
            switch (productLine.Product.SKU)
            {
                case "B":
                {
                    while (quantity >= 3)
                    {
                        totalCost += discount.Value;
                        quantity -= 3;
                    }

                    totalCost += quantity * productPrice;
                    return totalCost;
                }
                case "D":
                {
                    while (quantity >= 2)
                    {
                        var discountPercent = 1 - discount.Value / 100;
                        totalCost += 2 * productPrice * discountPercent;
                        quantity -= 2;
                    }

                    totalCost += quantity * productPrice;
                    return totalCost;
                }
                default:
                    break;
            }

            return totalCost;
        }
    }
}