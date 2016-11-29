using System;
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
        public string UsrName { get; set; }
        public string Password { get; set; }
        public bool Confirmed { get; set; }
        public string PaidStringCode { get; set; }
        public string PhoneNr { get; set; }

       
        public Address Address { get; set; }

        
        public Schedule Schedule { get; set; }

        public enum Positions
        {
            Teacher, Student
        }

        public Positions Position { get; set; }
    }
}
