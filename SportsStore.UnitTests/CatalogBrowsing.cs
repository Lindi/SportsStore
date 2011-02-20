using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestFixture]
    class CatalogBrowsing
    {
        [Test]
        public void Can_View_A_Single_Page_Of_Products() 
        {
            //  Arrange: Put 5 products in a mock repository
            IProductsRepository repository = 
                UnitTestHelpers.MockProductsRepository
                (
                    new Product { Name = "p1" },
                    new Product { Name = "p2" },
                    new Product { Name = "p3" },
                    new Product { Name = "p4" },
                    new Product { Name = "p5" }
                );

            //  Create a products controller
            //  Again, we're using an implicitly typed variable here
            var controller = new ProductsController(repository);

            //  Set the controller's page size to 3
            //  We haven't implemented the PageSize property yet
            //  so the test will fail
            controller.PageSize = 3;

            //  Act: Ask the controller for page 2
            var result = controller.List(2);

            //  Assert: ... they'll see the last two products?
            var displayedProducts = (ProductListViewModel)result.ViewData.Model;
            displayedProducts.Products.Count.ShouldEqual(2);
            displayedProducts.Products[0].Name.ShouldEqual("p4");
            displayedProducts.Products[1].Name.ShouldEqual("p5");
        }

    }
}
