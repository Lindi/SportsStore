using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests
{
    public static class UnitTestHelpers
    {
        public static void ShouldEqual<T>(this T actualValue, T expectedValue)
        {
            Assert.AreEqual(expectedValue, actualValue);
        }

        //  Why wouldn't this method be in the test class itself?
        public static IProductsRepository MockProductsRepository(params Product[] products)
        {
            //  Generate a mock products repository using Moq
            //  Here, we're using an implicitly-typed variable
            //  Hmmm, so ... we pass an array of products to this method
            //  and this Moq class' Setup method points to the Products property
            //  of IProductsRepository, and then (aha) specifies that that
            //  method will return products as queryable when it's invoked
            var mockProductsRepository = new Mock<IProductsRepository>();
            mockProductsRepository.Setup(x => x.Products).Returns(products.AsQueryable());
            return mockProductsRepository.Object;
        }
    }
}
