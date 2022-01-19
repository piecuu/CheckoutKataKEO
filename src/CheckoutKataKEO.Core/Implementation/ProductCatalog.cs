using CheckoutKataKEO.Core.Interfaces;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core.Implementation
{
    public class ProductCatalog : IProductCatalog
    {
        private List<Product> _products;

        public ProductCatalog()
        {
            InitProductCatalog();
        }

        public Product GetProduct(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentNullException();
            }

            var product = _products.FirstOrDefault(x => x.SKU == sku);
            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }

        private void InitProductCatalog()
        {
            _products = new List<Product>
            {
                new("A", 10),
                new("B", 15),
                new("C", 40),
                new("D", 55)
            };
        }
    }
}