using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class ImageToHost : AbstractEntity
    {
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public byte[] Bytes { get; set; }

    }
}
