using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cutouts_Generator
{
    public partial class Metadata
    {
        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("symbol")]
        public string symbol { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("image")]
        public string image { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> attributes { get; set; }

        [JsonProperty("properties")]
        public _Properties properties { get; set; }

        public Metadata(string name, string symbol,string description, string image, List<Attribute> attributes, _Properties properties)
        {
            this.name = name;
            this.symbol = symbol;
            this.description = description;
            this.image = image;
            this.attributes = attributes;
            this.properties = properties;
        }
        public Metadata(string name, string symbol, string image, List<Attribute> attributes, _Properties properties)
        {
            this.name = name;
            this.symbol = symbol;
            this.image = image;
            this.description = "cutouts test -_-";
            this.attributes = attributes;
            this.properties = properties;
        }
    }

    public partial class Attribute
    {
        [JsonProperty("trait_type")]
        public string trait_type { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

        public Attribute(string trait_type, string value)
        {
            this.trait_type = trait_type;
            this.value = value;
        }
    }

    public partial class _Properties
    {
        [JsonProperty("files")]
        public List<_File> files { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        public _Properties(List<_File> files, string category)
        {
            this.files = files;
            this.category = category;
        }
    }

    public partial class _File
    {
        [JsonProperty("uri")]
        public string uri { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        public _File(string uri, string type)
        {
            this.uri = uri;
            this.type = type;
        }
    }

    public partial class Metadata
    {
        public static Metadata FromJson(string json) => JsonConvert.DeserializeObject<Metadata>(json, Cutouts_Generator.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Metadata self) => JsonConvert.SerializeObject(self, Cutouts_Generator.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
