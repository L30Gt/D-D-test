using dandd.Models;
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
        private readonly HttpClient client;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string baseUrl = "https://www.dnd5eapi.co/api/";

        public ClassService()
        {
            client = new HttpClient();
            Races = new ObservableCollection<Races>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public ObservableCollection<Races> Races { get; private set; }

        public async Task<ObservableCollection<Races>> GetAllClassesAsync()
        {
            var url = $"{baseUrl}/races";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Races = JsonSerializer.Deserialize<ObservableCollection<Races>>(content, _serializerOptions);
                }
                return new ObservableCollection<Races>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception("Erro não esperado.");
            }
        }
    }
}
