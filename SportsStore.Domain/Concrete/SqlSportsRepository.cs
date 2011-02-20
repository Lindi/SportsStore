using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class SqlSportsRepository : IProductsRepository
    {
        //  Table is a generic class Table<T>
        private Table<Product> productsTable;

        public SqlSportsRepository(string connectionString)
        {
            //  GetTable is a generic method Table<T> T GetTable( T type );
            productsTable = (new DataContext(connectionString).GetTable<Product>());
        }

        public IQueryable<Entities.Product> Products
        {
            get { return productsTable; }
        }
    }
}
