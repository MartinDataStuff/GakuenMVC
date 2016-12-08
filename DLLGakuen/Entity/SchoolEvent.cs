using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class SchoolEvent : AbstractEntity
    {
        public string Name { get; set; }
        public int Minuttes { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public Schedule Schedule { get; set; }
    }
}
