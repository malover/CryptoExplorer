using CryproExplorer.Core;
using CryproExplorer.MVVM.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryproExplorer.MVVM.ViewModel
{
    public class AssetsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;
        private AssetOverview _selectedAsset;
        private string _searchboxText;
        private ObservableCollection<AssetOverview> _assets;
        private ObservableCollection<AssetOverview> _visibleAssets;

        public AssetOverview SelectedAsset
        {
            get { return _selectedAsset; }
            set
            {
                _mainViewModel.CurrentView = new DetailsViewModel(value.Symbol);
            }
        }

        public string SearchboxText
        {
            get { return _searchboxText; }
            set
            {
                _searchboxText = value;
                OnPropertyChanged();
                Search(value);
            }
        }

        public HttpClient Client { get; set; }
        public ObservableCollection<AssetOverview> Assets
        {
            get { return _assets; }
            set
            {
                _assets = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AssetOverview> VisibleAssets
        {
            get { return _visibleAssets; }
            set
            {
                _visibleAssets = value;
                OnPropertyChanged();
            }
        }
        public AssetsViewModel(MainViewModel mainviewmodel)
        {
            _assets = new ObservableCollection<AssetOverview>();
            _mainViewModel = mainviewmodel;
            _searchboxText = "";
            Client = new HttpClient();
            Task.Run(() => PopulateList());
            _visibleAssets = _assets;
        }

        private async Task PopulateList()
        {
            Uri uri = new Uri("http://api.coincap.io/v2/assets");

            var request = await Client.GetAsync(uri);
            var jsonString = await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CurrencyModelOverview>(jsonString);

            foreach(var asset in model.Assets)
            {
                _assets.Add(asset);
            }
        }

        private void Search(string searchText)
        {
            searchText = searchText.ToLower();
            var result = _assets.Where(x => x.Name.ToLower().Contains(searchText) || x.Symbol.ToLower().Contains(searchText)).ToList();

            var temp = new ObservableCollection<AssetOverview>();
            foreach (var item in result)
            {
                temp.Add(item);
            }
            VisibleAssets = temp;
        }
    }
}
