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
    class AddressGateway : IServiceGateway<Address>
    {
        private readonly UriAzure _azure =
        new UriAzure();

        public Address Create(Address t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/addresses", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Address>().Result;
                }
            }
            return null;
        }

        public Address Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"/api/addresses/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Address>().Result;
                }
                return null;
            }
        }

        public List<Address> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/addresses").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Address>>().Result;
                }
            }
            return new List<Address>();
        }

        public Address Update(Address t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync($"/api/addresses/{t.Id}", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Address>().Result;
                }
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.DeleteAsync($"/api/addresses/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Address>().Result != null;
                }
                return false;
            }
        }
    }
}
