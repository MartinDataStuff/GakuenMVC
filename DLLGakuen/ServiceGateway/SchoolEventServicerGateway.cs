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


    class SchoolEventServicerGateway : IServiceGateway<SchoolEvent>
    {
        private readonly UriAzure _azure =
      new UriAzure();

        public SchoolEvent Create(SchoolEvent t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/SchoolEvents", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<SchoolEvent>().Result;
                }
            }
            return null;
        }

        public SchoolEvent Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"/api/SchoolEvents/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<SchoolEvent>().Result;
                }
                return null;
            }
        }

        public List<SchoolEvent> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/SchoolEvents").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<SchoolEvent>>().Result;
                }
            }
            return new List<SchoolEvent>();
        }

        public SchoolEvent Update(SchoolEvent t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync($"/api/SchoolEvents/{t.Id}", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<SchoolEvent>().Result;
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

                var response = client.DeleteAsync($"/api/schedules/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<SchoolEvent>().Result != null;
                }
                return false;
            }
        }
    }
}
