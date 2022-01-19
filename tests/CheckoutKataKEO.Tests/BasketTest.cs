using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKataKEO.Core;
using CheckoutKataKEO.Core.Implementation;
using CheckoutKataKEO.Core.Interfaces;
using NUnit.Framework;

namespace CheckoutKataKEO.Tests
{
    public class BasketTest
    {
        private Basket _basket;
        private IProductCatalog _productCatalog;
        private IDiscountCatalog _discountCatalog;
        private IDiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            _productCatalog = new ProductCatalog();
            _discountCatalog = new DiscountCatalog();
            _discountService = new DiscountService();

            _basket = new Basket(_productCatalog, _discountCatalog, _discountService);
        }
    }
}
