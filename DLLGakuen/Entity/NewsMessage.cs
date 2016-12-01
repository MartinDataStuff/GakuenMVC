﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class NewsMessage : AbstractEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public ImageToHost ImageToHost { get; set; }
        public VideoToHost VideoToHost { get; set; }
    }
}
