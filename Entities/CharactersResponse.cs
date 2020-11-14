using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GlobalHeroes.Entities
{    
    public class CharactersResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHtml { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("comics")]
        public Comics Comics { get; set; }

        [JsonProperty("stories")]
        public Stories Stories { get; set; }

        [JsonProperty("events")]
        public Comics Events { get; set; }

        [JsonProperty("series")]
        public Comics Series { get; set; }
    }

    public partial class Comics
    {
        [JsonProperty("available")]
        public string Available { get; set; }

        [JsonProperty("returned")]
        public string Returned { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<ComicsItem> Items { get; set; }
    }

    public partial class ComicsItem
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Stories
    {
        [JsonProperty("available")]
        public string Available { get; set; }

        [JsonProperty("returned")]
        public string Returned { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<StoriesItem> Items { get; set; }
    }

    public partial class StoriesItem
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string UrlUrl { get; set; }
    }
}
