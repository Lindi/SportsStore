using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SportsStore.Domain.Entities
{
    [Table(Name="Products")]
    public class Product
    {
        [Column] public int ProductID { get; set; }
        [Column] public string Name { get; set; }
        [Column] public string Description { get; set; }
        [Column] public decimal Price { get; set; }
        [Column] public string Category { get; set; }
    }
}
