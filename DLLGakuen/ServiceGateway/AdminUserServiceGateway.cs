using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DLLGakuen.Entity;

namespace DLLGakuen.ServiceGateway
{
    class AdminUserServiceGateway : IServiceGateway<AdminUser>
    {
        private readonly UriAzure _azure =
       new UriAzure();

        public AdminUser Create(AdminUser t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/adminusers", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<AdminUser>().Result;
                }
            }
            return null;
        }

        public AdminUser Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"/api/adminusers/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<AdminUser>().Result;
                }
                return null;
            }
        }

        public List<AdminUser> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/adminusers").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<AdminUser>>().Result;
                }
            }
            return new List<AdminUser>();
        }

        public AdminUser Update(AdminUser t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync($"/api/adminusers/{t.Id}", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<AdminUser>().Result;
                }
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync($"/api/adminusers/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<AdminUser>().Result != null;
                }
                return false;
            }
        }
    }
}
