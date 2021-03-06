﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class Schedule : AbstractEntity
    {
        
        public List<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();
        //public List<User> Users { get; set; }

        public enum Days
        {
            Fredag, Lørdag, Søndag
        }

        public Days Day { get; set; }
    }
}
