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
    public class ConverterViewModel : ObservableObject
    {
        private AssetOverview _selectedAsset1;
        private AssetOverview _selectedAsset2;
        private ObservableCollection<AssetOverview> _assetList;
        private ObservableCollection<AssetOverview> _visibleList1;
        private ObservableCollection<AssetOverview> _visibleList2;
        private string _searchboxText1;
        private string _searchboxText2;
        private decimal _currencyAmount;
        private decimal _currencyTransformed;
        private decimal _currencyPriceInUSD;

        public decimal CurrencyAmount
        {
            get
            {
                return _currencyAmount;
            }
            set
            {
                _currencyAmount = value;
                Convert(_currencyAmount);
                GetPriceInUsd(_currencyAmount);
                OnPropertyChanged();
            }
        }
        public decimal CurrencyTransformed
        {
            get
            {
                return _currencyTransformed;
            }
            set
            {
                _currencyTransformed = value;
                OnPropertyChanged();
            }
        }

        public decimal CurrencyPriceInUSD
        {
            get
            {
                return _currencyPriceInUSD;
            }
            set
            {
                _currencyPriceInUSD = value;
                OnPropertyChanged();
            }
        }
        public AssetOverview SelectedAsset1
        {
            get { return _selectedAsset1; }
            set
            {
                _selectedAsset1 = value;
                Convert(_currencyAmount);
                GetPriceInUsd(_currencyAmount);
                OnPropertyChanged();
            }
        }
        public AssetOverview SelectedAsset2
        {
            get { return _selectedAsset2; }
            set
            {
                _selectedAsset2 = value;
                Convert(_currencyAmount);
                GetPriceInUsd(_currencyAmount);
                OnPropertyChanged();
            }
        }
        public ObservableCollection<AssetOverview> VisibleList1
        {
            get { return _visibleList1; }
            set
            {
                _visibleList1 = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<AssetOverview> VisibleList2
        {
            get { return _visibleList2; }
            set
            {
                _visibleList2 = value;
                OnPropertyChanged();
            }
        }
        public string SearchboxText1
        {
            get { return _searchboxText1; }
            set
            {
                _searchboxText1 = value;
                OnPropertyChanged();
                Search(_searchboxText1, 1);
            }
        }
        public string SearchboxText2
        {
            get { return _searchboxText2; }
            set
            {
                _searchboxText2 = value;
                OnPropertyChanged();
                Search(_searchboxText2, 2);
            }
        }

        public HttpClient Client { get; set; }
        public ConverterViewModel()
        {
            Client = new HttpClient();
            _assetList = new ObservableCollection<AssetOverview>();
            _searchboxText1 = "";
            _searchboxText1 = "";
            Task.Run(() => PopulateList()).Wait();
            _selectedAsset1 = _assetList[0];
            _selectedAsset2 = _assetList[1];
            _currencyAmount = 1;
            Convert(_currencyAmount);
            GetPriceInUsd(_currencyAmount);
            _visibleList1 = _assetList;
            _visibleList2 = _assetList;
        }

        private async Task PopulateList()
        {
            Uri uri = new Uri("http://api.coincap.io/v2/assets");

            var request = await Client.GetAsync(uri);
            var jsonString = await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CurrencyModelOverview>(jsonString);

            foreach (var asset in model.Assets)
            {
                _assetList.Add(asset);
            }
        }

        private void Search(string searchText, int textbox)
        {
            searchText = searchText.ToLower();
            var result = _assetList.Where(x => x.Name.ToLower().Contains(searchText) || x.Symbol.ToLower().Contains(searchText)).ToList();

            var temp = new ObservableCollection<AssetOverview>();
            foreach (var item in result)
            {
                temp.Add(item);
            }
            if (textbox == 1)
                VisibleList1 = temp;
            else
                VisibleList2 = temp;
        }

        private void Convert(decimal amount)
        {
            decimal result = (SelectedAsset1.Price / SelectedAsset2.Price) * amount;
            CurrencyTransformed = (decimal)Math.Round(result, 5);
        }
        
        private void GetPriceInUsd(decimal amount)
        {
            CurrencyPriceInUSD = (decimal)Math.Round(SelectedAsset1.Price * _currencyAmount, 5);
        }
    }
}
