using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryproExplorer.MVVM.Model
{
    public partial class CurrencyModelCU
    {
        [JsonProperty("asset")]
        public Asset Asset { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("asset_id")]
        public string AssetId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public decimal Volume24H { get; set; }

        [JsonProperty("change_1h")]
        public double Change1H { get; set; }

        [JsonProperty("change_24h")]
        public double Change24H { get; set; }

        [JsonProperty("change_7d")]
        public double Change7D { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
