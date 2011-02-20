using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using System.ComponentModel;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;


namespace SportsStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;
        public int PageSize = 4;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
            //  productsRepository = new FakeProductsRepository();
            //            string connectionString = @"Server=.\SQLEXPRESS;Database=SportsStore;Trusted_Connection=yes;";
            //            productsRepository = new SqlSportsRepository(connectionString);
        }

        public ViewResult List([DefaultValue(1)] int page)
        {
            //  Now I understand what IQueryable is
            //  I think that LINQ adds a static extension method
            //  which resolves the type you send?  And then it
            //  configures whatever type it can configure to be 'queryable'
            //  or to allow query expressions to be written on it

            //  In this case, the Products property of IProductsRepository
            //  returns IQueryable<Products>, and that IQueryable collection
            //  has these methods on it

            //  Remember when you pass a collection to this
            //  view method like this, you're passing data to the
            //  Model object

            //  Grab the products list so we can pass the total
            //  number of products to the pagingInfo view model
            IQueryable<Product> products = productsRepository.Products;

            //  Now query that list of products to get the products
            //  to be viewed on the current page
            IList<Product> productList = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();


            PagingInfo pagingInfo
                = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = products.Count(),
                    ItemsPerPage = PageSize
                };

            var viewModel
                = new ProductListViewModel
                {
                    PagingInfo = pagingInfo,
                    Products = productList
                };
            return View(viewModel);
        }
    }
}
