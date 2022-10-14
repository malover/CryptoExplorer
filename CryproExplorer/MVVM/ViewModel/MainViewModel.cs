using CryproExplorer.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CryproExplorer.MVVM.Model;
using System.Windows;

namespace CryproExplorer.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AssetsViewCommand { get; set; }
        public RelayCommand ConverterViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public AssetsViewModel AssetsVm { get; set; }
        public ConverterViewModel ConverterVm { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();    
            }
        }


        public MainViewModel()
        {
            HomeVm = new HomeViewModel(this);
            AssetsVm = new AssetsViewModel(this);
            ConverterVm = new ConverterViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            AssetsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AssetsVm;
            });

            ConverterViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConverterVm;
            });
        }
    }
}
