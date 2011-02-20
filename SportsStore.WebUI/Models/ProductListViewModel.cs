using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public PagingInfo PagingInfo { get; set; }
        public IList<Product> Products { get; set; }
    }
}