using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestFixture]
    public class DisplayingPageLinks
    {
        [Test]
        public void Can_Generate_Links_To_Other_Pages()
        {
            //  Arrange: Create a reference to the HtmlHelper class instance
            //  We can use a null reference here because we're going to extend
            //  the HtmlHelper class with an extension method
            HtmlHelper html = null;

            //  Arrange: The helper should take a paging info instance
            //  and a lambda to specify the URLs
            //  Create an anonymous instance of the paging info class
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //  Create a lambda expression that takes an 
            //  integer and spits out a string
            Func<int, string> pageUrl = i => "Page" + i;

            //  Act: Create the html string to supply to the view
            MvcHtmlString result = html.PageLinks(pagingInfo, pageUrl);

            //  Assert: Here's how it should format the links
            result.ToString().ShouldEqual(@"<a href=""Page1"">1</a>
<a class=""selected"" href=""Page2"">2</a>
<a href=""Page3"">3</a>
");

        }

        [Test]
        public void Product_Lists_Include_Correct_Page_Numbers()
        {
            //  Arrange: If there are five products in the repository
            var mockRepository = UnitTestHelpers.MockProductsRepository
                (
                    new Product { Name = "p1" },
                    new Product { Name = "p2" },
                    new Product { Name = "p3" },
                    new Product { Name = "p4" },
                    new Product { Name = "p5" }
                );

            //  Arrange: Create a new ProductsController with the mock repository
            //  and a page size of 3
            var controller = new ProductsController(mockRepository) { PageSize = 3 };

            //  Act: Grab the view data model for page 2
            var result = controller.List(2);

            //  Assert: Check all the data in the model
            var viewModel = (ProductListViewModel) result.ViewData.Model ;
            PagingInfo pagingInfo = viewModel.PagingInfo ;
            pagingInfo.CurrentPage.ShouldEqual(2);
            pagingInfo.TotalPages.ShouldEqual(2);
            pagingInfo.ItemsPerPage.ShouldEqual(3);
            pagingInfo.TotalItems.ShouldEqual(5);
        }
    }
}
