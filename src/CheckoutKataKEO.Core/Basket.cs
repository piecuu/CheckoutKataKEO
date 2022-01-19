using CheckoutKataKEO.Core.Interfaces;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core
{
    public class Basket
    {
        private readonly IProductCatalog _productCatalog;
        private readonly IDiscountCatalog _discountCatalog;
        private readonly IDiscountService _discountService;
        private readonly List<ProductLine> _productLines;

        public Basket(IProductCatalog productCatalog, IDiscountCatalog discountCatalog,
            IDiscountService discountService)
        {
            _productCatalog = productCatalog;
            _discountCatalog = discountCatalog;
            _discountService = discountService;
            _productLines = new List<ProductLine>();
        }

        public void AddProduct(string sku)
        {
            var product = _productCatalog.GetProduct(sku);
            var productLine = _productLines.FirstOrDefault(x => x.Product.SKU == product.SKU);
            if (productLine is null)
            {
                _productLines.Add(new ProductLine(product));
            }
            else
            {
                productLine.AddQuantity();
            }
        }

        public int TotalQuantity()
        {
            return _productLines.Sum(x => x.Quantity);
        }

        public decimal TotalCostWithoutDiscount()
        {
            return _productLines.Sum(x => x.Quantity * x.Product.Price);
        }

        public decimal TotalCostWithDiscount()
        {
            var result = 0.0m;
            foreach (var productLine in _productLines)
            {
                var discount = _discountCatalog.GetDiscount(productLine.Product.SKU);
                if (discount is null)
                {
                    result += productLine.Product.Price * productLine.Quantity;
                }
                else
                {
                    result += _discountService.ApplyProductDiscount(productLine, discount);
                }
            }

            return result;
        }
    }
}