using ClientconvertisseurV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace ClientconvertisseurV1.Services
{
    public class WSService : IService
    {
        static HttpClient client = new HttpClient();

        public WSService()
        {
            client.BaseAddress = new Uri("http://localhost:64195/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {s
                return await httpClient.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
