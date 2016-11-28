﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
    public class User : AbstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNr { get; set; }

       
        public int AddressId { get; set; }
        public Address Address { get; set; }

        
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public enum Positions
        {
            Teacher, Student
        }

        public Positions Position { get; set; }
    }
}
