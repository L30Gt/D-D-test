using CommunityToolkit.Mvvm.ComponentModel;
using dandd.Models;
using dandd.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dandd.ViewModels
{
    internal partial class RaceViewModel : ObservableObject, IDisposable
    {
        private readonly ClassService _classService;

        [ObservableProperty]
        public string _Index;
        [ObservableProperty]
        public string _Name;
        [ObservableProperty]
        public string _Url;

        [ObservableProperty]
        public ObservableCollection<Races> _races;


        public RaceViewModel()
        {
            Races = new ObservableCollection<Races>();
            _classService = new ClassService();
        }

        public ICommand GetRacesCommand => new Command(async () => await LoadRacesAsync());

        private async Task LoadRacesAsync()
        {
            try
            {
                Races = await _classService.GetAllClassesAsync();       
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine("Exceção do service");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
