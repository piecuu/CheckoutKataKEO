namespace CheckoutKataKEO.Core.Models
{
    public class Product
    {
        public string SKU { get; set; }

        public decimal Price { get; set; }

        public Product(string sku, decimal price)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentNullException();
            }

            SKU = sku;
            Price = price;
        }
    }
}