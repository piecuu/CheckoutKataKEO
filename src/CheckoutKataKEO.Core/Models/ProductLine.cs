namespace CheckoutKataKEO.Core.Models
{
    public class ProductLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public ProductLine(Product product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}