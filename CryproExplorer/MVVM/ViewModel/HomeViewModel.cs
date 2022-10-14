using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryproExplorer.MVVM.Model;
using System.ComponentModel;
using CryproExplorer.Core;
using System.Windows.Input;
using System.Windows;

namespace CryproExplorer.MVVM.ViewModel
{
    public class HomeViewModel
    {

        private AssetOverview _selectedAsset;
        private readonly MainViewModel _mainViewModel;
        public HttpClient Client { get; set; }
        public AssetOverview SelectedAsset
        {
            get { return _selectedAsset; }
            set
            {
                _mainViewModel.CurrentView = new DetailsViewModel(value.Symbol);
            }
        }
        public ObservableCollection<AssetOverview> Assets { get; set; }
        public HomeViewModel(MainViewModel mainviewmodel)
        {
            Client = new HttpClient();
            Assets = new ObservableCollection<AssetOverview>();
            _mainViewModel = mainviewmodel;
            Task.Run(() => PopulateCollection()).Wait();
        }

        public async Task PopulateCollection()
        {
            Uri uri = new Uri("http://api.coincap.io/v2/assets");

            var request = await Client.GetAsync(uri);
            var jsonString = await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CurrencyModelOverview>(jsonString);


            ObservableCollection<CurrencyModelOverview> temp = new ObservableCollection<CurrencyModelOverview>();

            for (int i = 0; Assets.Count < 10; i++)
            {
                Assets.Add(model.Assets[i]);
            }
        }
    }
}
