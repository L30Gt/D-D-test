using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dandd.Services
{
    public class ClassService
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://www.dnd5eapi.co/api/";

        public danddServices()
        {
            client = new HttpClient();
            Races = new ObservableCollection<Race>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<dandd>> GetDanddsAsync()
        {
            var url = $"{baseUrl}/races";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Races = JsonSerializer.Deserialize<ObservableCollection<Race>>(content, _serializerOptions);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception("Erro não esperado.");
            }
        }
    }
}
