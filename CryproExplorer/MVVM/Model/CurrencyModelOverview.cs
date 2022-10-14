using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproExplorer.MVVM.Model
{
    public class CurrencyModelOverview
    {

        [JsonProperty("data")]
        public AssetOverview[] Assets { get; set; }
    }

    public partial class AssetOverview
    {
        [JsonProperty("id")]
        public string AssetId { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("priceUsd")]
        public decimal Price { get; set; }
    }
}

