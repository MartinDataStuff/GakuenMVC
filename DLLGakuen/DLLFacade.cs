using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLGakuen.Entity;
using DLLGakuen.ServiceGateway;

namespace DLLGakuen
{
   public class DllFacade
    {
        public IServiceGateway<Address> GetAddressServiceGateway()
        {
            return new AddressGateway();
        }

        public IServiceGateway<EventMessage> GetEventMessageServiceGateway()
        {
            return new EventMessageServiceGateway();
        }

        public IServiceGateway<NewsMessage> GetNewsMessageServiceGateway()
        {
            return new NewsMessageServiceGateway();
        }

        public IServiceGateway<Schedule> GetScheduleServiceGateway()
        {
            return new ScheduleServiceGateway();
        }

        public IServiceGateway<User> GetUserServiceGateway()
        {
            return  new UserServiceGateway();
        }

        public IServiceGateway<AdminUser> GetAdminUserServiceGateway()
        {
            return new AdminUserServiceGateway();
        }

        public IServiceGateway<ImageToHost> GetImageTohostServiceGateway()
        {
            return new ImageToHostServiceGateway();
        }
    }
}
