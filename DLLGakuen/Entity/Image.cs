using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class Image : AbstractEntity
    {
        public string ImageName { get; set; }
        public byte[] Bytes { get; set; }
    }
}
