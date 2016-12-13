using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DLLGakuen.Entity;
using static DLLGakuen.Entity.User;

namespace GakuenMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UsrName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string PhoneNr { get; set; }
        public int ContactPersonPhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAdmin { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Gakuen", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<DLLGakuen.Entity.AdminUser> AdminUsers { get; set; }

        public System.Data.Entity.DbSet<DLLGakuen.Entity.SchoolEvent> SchoolEvents { get; set; }

        public System.Data.Entity.DbSet<DLLGakuen.Entity.OrderList> OrderLists { get; set; }

        public System.Data.Entity.DbSet<DLLGakuen.Entity.Product> Products { get; set; }

        public System.Data.Entity.DbSet<DLLGakuen.Entity.Schedule> Schedules { get; set; }
    }
}