using CommunityToolkit.Mvvm.ComponentModel;
using dandd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dandd.Models;
using System.Collections.ObjectModel;

namespace dandd.ViewModels
{
    internal partial class ClassViewModel : ObservableObject
    {
        
        private readonly ClassService _classService;

        [ObservableProperty]
        public string _Index;
        [ObservableProperty]
        public string _Name;
        [ObservableProperty]
        public string _Url;

        public ObservableCollection<Class> _class;
    
    }
}
