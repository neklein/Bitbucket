using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Models
{
    public class MarvelResult
    {
        [JsonProperty("Data")]
        public MarvelData CharacterData { get; set; }
    }

    public class MarvelData
    {
        [JsonProperty("results")]
        public IEnumerable<CharJson> characterList { get; set; }
    }

    public class CharJson
    {
        [JsonProperty("name")]
        public string CharName { get; set; }

        [JsonProperty("description")]
        public string CharDescription { get; set; }

        [JsonProperty("thumbnail")]
        public MarvelThumbnail CharThumb { get; set; }

        [JsonProperty("urls")]
        public IEnumerable<MarvelURLs> CharURLs { get; set; }
    }

    public class MarvelThumbnail
    {
        [JsonProperty("path")]
        public string ThumbURL { get; set; }

        [JsonProperty("extension")]
        public string ThumbExt { get; set; }
    }

    public class MarvelURLs
    {
        [JsonProperty("type")]
        public string URLType { get; set; }

        [JsonProperty("url")]
        public string URLValue { get; set; }
    }
}