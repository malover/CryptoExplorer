using CryproExplorer.Core;
using CryproExplorer.MVVM.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryproExplorer.MVVM.ViewModel
{
    public class DetailsViewModel : ObservableObject
    {
        private ObservableCollection<Market> _markets;
        private Asset _asset;
        private readonly Uri _baseUri = new Uri("https://cryptingup.com/api/assets/");
        public HttpClient Client { get; set; }

        public ObservableCollection<Market> Markets
        {
            get
            {
                return _markets;
            }
            set
            {
                _markets = value;
                OnPropertyChanged();
            }
        }
        public Asset Asset
        {
            get
            {
                return _asset;
            }
            set
            {
                _asset = value;
                OnPropertyChanged();
            }
        }

        public DetailsViewModel(string id)
        {
            Client = new HttpClient();
            Markets = new ObservableCollection<Market>();

            Task.Run(() => RequestCurrencyDetails(id));

            Task.Run(() => RequestAllMarkets(id));
        }

        private async Task RequestCurrencyDetails(string id)
        { 
            Uri uri = new Uri(_baseUri, id);

            var request = await Client.GetAsync(uri);
            var jsonString = await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<CurrencyModelCU>(jsonString);

            Asset = model.Asset;
        }
        private async Task RequestAllMarkets(string id)
        {
            string marketPath = id + "/markets";
            Uri uri = new Uri(_baseUri, marketPath);

            var request = await Client.GetAsync(uri);
            var jsonString = await request.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<MarketsModel>(jsonString);


            ObservableCollection<Market> temp = new ObservableCollection<Market>();

            for (int i = 0; i < 10; i++)
            {
                temp.Add(model.Markets[i]);
            }
            Markets = temp;
        }
    }
}
