using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class FakeProductsRepository : IProductsRepository
    {
        private static IQueryable<Product> fakeProducts = new List<Product> {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf Board", Price = 179 },
            new Product { Name = "Running Shoes", Price = 95 }
        }.AsQueryable();



        public IQueryable<Product> Products
        {
            get { return fakeProducts; }
        }
    }
}
