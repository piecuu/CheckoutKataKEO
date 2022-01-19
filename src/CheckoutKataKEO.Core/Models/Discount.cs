namespace CheckoutKataKEO.Core.Models
{
    public class Discount
    {
        public string SKU { get; set; }

        public decimal Value { get; set; }

        public Discount(string sku, decimal value)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentNullException();
            }

            SKU = sku;
            Value = value;
        }
    }
}