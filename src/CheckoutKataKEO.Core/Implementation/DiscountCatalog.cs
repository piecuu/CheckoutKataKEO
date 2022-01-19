using CheckoutKataKEO.Core.Interfaces;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Implementation
{
    public class DiscountCatalog : IDiscountCatalog
    {
        private List<Discount> _discounts;

        public DiscountCatalog()
        {
            InitDiscountCatalog();
        }

        public Discount? GetDiscount(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentNullException();

            var discount = _discounts.FirstOrDefault(x => x.SKU == sku);
            return discount;
        }

        private void InitDiscountCatalog()
        {
            _discounts = new List<Discount>();

            _discounts.Add(new Discount("B", 40));
            _discounts.Add(new Discount("D", 25));
        }
    }
}