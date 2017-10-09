using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SWAPIConsole.Data
{
    public class SWAPIModels
    {
        [JsonProperty("results")]
        public IEnumerable<ShipJson> shipList { get; set; }


    }

    public class ShipJson
    {
        [JsonProperty("name")]
        public string ShipName { get; set; }
        [JsonProperty("model")]
        public string ShipModel { get; set; }
        [JsonProperty("starship_class")]
        public string ShipClass { get; set; }
    }
}
