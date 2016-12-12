using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLGakuen.Entity;

namespace GakuenMVC.Models
{
    class ShoppingCart
    {
        public IDictionary<int, Product> Products { get; set; } = new Dictionary<int, Product>();
    }
}
