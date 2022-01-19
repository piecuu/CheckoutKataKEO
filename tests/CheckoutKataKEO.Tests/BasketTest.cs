using System;
using CheckoutKataKEO.Core;
using CheckoutKataKEO.Core.Implementation;
using CheckoutKataKEO.Core.Interfaces;
using CheckoutKataKEO.Core.Services;
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

        [Test]
        public void When_BasketIsEmpty_Then_TotalCostWithoutDiscountIsZero()
        {
            var totalCost = _basket.TotalCostWithoutDiscount();

            Assert.AreEqual(0, totalCost);
        }

        [Test]
        public void When_BasketIsEmpty_Then_TotalCostWithDiscountIsZero()
        {
            var totalCost = _basket.TotalCostWithDiscount();

            Assert.AreEqual(0, totalCost);
        }

        [Test]
        public void When_SingleProductIsAddedToBasket_Then_TotalCostWithoutDiscountEqualsProductValue()
        {
            _basket.AddProduct("A");

            var totalCost = _basket.TotalCostWithoutDiscount();

            Assert.AreEqual(10, totalCost);
        }

        [Test]
        public void When_SingleProductIsAddedToBasket_Then_TotalCostWithDiscountEqualsProductValueWithDiscount()
        {
            _basket.AddProduct("A");

            var totalCost = _basket.TotalCostWithoutDiscount();

            Assert.AreEqual(10, totalCost);
        }

        [Test]
        public void When_UnknownProductIsAddedToBasket_Then_ThrowException()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                _basket.AddProduct("X");
            });
        }

        [Test]
        public void When_DifferentProductsAreAddedToBasket_Then_TotalCostWithoutDiscountEqualsProductsValue()
        {
            _basket.AddProduct("A");
            _basket.AddProduct("B");
            _basket.AddProduct("C");
            _basket.AddProduct("D");

            var totalCost = _basket.TotalCostWithoutDiscount();

            Assert.AreEqual(120, totalCost);
        }

        [Test]
        public void When_DifferentProductsAreAddedToBasket_Then_TotalCostWithDiscountEqualsProductsValue()
        {
            _basket.AddProduct("A");
            _basket.AddProduct("B");
            _basket.AddProduct("C");
            _basket.AddProduct("D");

            var totalCost = _basket.TotalCostWithDiscount();

            Assert.AreEqual(120, totalCost);
        }

        [Test]
        public void When_ExistingProductIsAdded_Then_BasketQuantityEqualsProductQuantity()
        {
            _basket.AddProduct("A");
            _basket.AddProduct("A");

            var basketQuantity = _basket.TotalQuantity();

            Assert.AreEqual(2, basketQuantity);
        }

        [Test]
        public void When_SingleProductWithDiscountIsMultipleAddedToBasket_Then_TotalCostIsCorrect()
        {
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");

            var totalCost = _basket.TotalCostWithDiscount();

            Assert.AreEqual(80, totalCost);
        }

        [Test]
        public void When_MultipleProductsWithDiscountAreMultipleAddedToBasket_Then_TotalCostIsCorrect()
        {
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");

            _basket.AddProduct("D");
            _basket.AddProduct("D");
            _basket.AddProduct("D");

            var totalCost = _basket.TotalCostWithDiscount();

            Assert.AreEqual(217.5, totalCost);
        }

        [Test]
        public void When_MultipleProductsWithAndWithoutDiscountsAreAddedToBasket_Then_TotalCostIsCorrect()
        {
            _basket.AddProduct("A");
            _basket.AddProduct("A");

            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");
            _basket.AddProduct("B");

            _basket.AddProduct("C");
            _basket.AddProduct("C");
            _basket.AddProduct("C");

            _basket.AddProduct("D");
            _basket.AddProduct("D");
            _basket.AddProduct("D");

            var totalCost = _basket.TotalCostWithDiscount();

            Assert.AreEqual(357.5, totalCost);
        }
    }
}