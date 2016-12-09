using System;
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
        public bool Confirmed { get; set; }
        public string PaidStringCode { get; set; }
        public string PhoneNr { get; set; }
        public Address Address { get; set; }
        public DateTime Birthday { get; set; }
        public int ContactPersonPhoneNumber { get; set; }

        //Login information
        public string UsrName { get; set; }
        public string Password { get; set; }
        //Whether the user has accepted the confirm email
        public bool ConfirmedUser { get; set; }
        public bool isAdmin { get; set; }

        
        public List<SchoolEvent> SchoolEvents { get; set; }
        public enum Positions
        {
            Teacher, Student
        }
        public Positions Position { get; set; }
    }
}
