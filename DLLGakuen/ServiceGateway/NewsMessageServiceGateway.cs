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
    class NewsMessageServiceGateway : IServiceGateway<NewsMessage>
    {
        private readonly UriAzure _azure =
       new UriAzure();


        public NewsMessage Create(NewsMessage t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/newsMessages", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<NewsMessage>().Result;
                }
            }
            return null;
        }

        public NewsMessage Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"/api/newsMessages/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<NewsMessage>().Result;
                }
                return null;
            }
        }

        public List<NewsMessage> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/newsMessages").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<NewsMessage>>().Result;
                }
            }
            return new List<NewsMessage>();
        }

        public NewsMessage Update(NewsMessage t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.DataBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync($"/api/newsMessages/{t.Id}", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<NewsMessage>().Result;
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

                var response = client.DeleteAsync($"/api/newsMessages/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<NewsMessage>().Result != null;
                }
                return false;
            }
        }
    }
}
