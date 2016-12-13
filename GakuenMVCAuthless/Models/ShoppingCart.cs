using System.Collections.Generic;
using DLLGakuen.Entity;

namespace GakuenMVCAuthless.Models
{
    class ShoppingCart
    {
        public IDictionary<int, Product> Products { get; set; } = new Dictionary<int, Product>();
    }
}
