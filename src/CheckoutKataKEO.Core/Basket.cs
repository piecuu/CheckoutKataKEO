using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CheckoutKataKEO.Core.Models;

namespace CheckoutKataKEO.Core
{
    public class Basket
    {
        private readonly List<ProductLine> _productLines;

        public Basket()
        {
            _productLines = new List<ProductLine>();
        }

        public int TotalQuantity() => _productLines.Sum(x => x.Quantity);

        public decimal TotalCostWithoutDiscount() => _productLines.Sum(x => x.Quantity * x.Product.Price);

        public void AddProduct(string sku)
        {

        }
    }
}
