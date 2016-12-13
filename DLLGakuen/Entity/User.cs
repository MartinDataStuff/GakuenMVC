﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen.Entity
{
        public class User : AbstractEntity
        {
            //Personal Information
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNr { get; set; }
            public Address Address { get; set; }
            public DateTime Birthday { get; set; }
            public int ContactPersonPhoneNumber { get; set; }



            //Login information
            public string UsrName { get; set; }
            public string Password { get; set; }
            //Whether the user has accepted the confirm email
            public bool ConfirmedUser { get; set; }


            //Shop oriented propaties
            public List<OrderList> OrderLists { get; set; } = new List<OrderList>();

            //School oriented propaties
            public List<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();

            public enum Positions
            {
                Teacher, Student
            }
            public Positions Position { get; set; }
        }
    }
