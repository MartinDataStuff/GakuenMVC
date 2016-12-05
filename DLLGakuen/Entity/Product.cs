using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class Product : AbstractEntity
    {
        public int id { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<OrderList> OrderLists { get; set; } = new List<OrderList>();
    }
}
