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
    class ScheduleServiceGateway : IServiceGateway<Schedule>
    {
        private readonly UriAzure _azure =
       new UriAzure();

        public Schedule Create(Schedule t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/schedules", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Schedule>().Result;
                }
            }
            return null;
        }

        public Schedule Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"/api/schedules/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Schedule>().Result;
                }
                return null;
            }
        }

        public List<Schedule> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/schedules").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Schedule>>().Result;
                }
            }
            return new List<Schedule>();
        }

        public Schedule Update(Schedule t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_azure.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PutAsJsonAsync($"/api/schedules/{t.Id}", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Schedule>().Result;
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

                var response = client.DeleteAsync($"/api/schedules/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Schedule>().Result != null;
                }
                return false;
            }
        }
    }
}
