using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostPublishCLI
{
    public partial class Post
    {
        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("mobiledoc", NullValueHandling = NullValueHandling.Ignore)]
        //public string Mobiledoc { get; set; }

        [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
        public string Html { get; set; }

        [JsonProperty("feature_image", NullValueHandling = NullValueHandling.Ignore)]
        public Uri FeatureImage { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("custom_excerpt", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomExcerpt { get; set; }

        [JsonProperty("canonical_url", NullValueHandling = NullValueHandling.Ignore)]
        public string CanonicalUrl { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        [JsonProperty("authors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Authors { get; set; }

        [JsonProperty("og_image", NullValueHandling = NullValueHandling.Ignore)]
        public string OgImage { get; set; }

        [JsonProperty("og_title", NullValueHandling = NullValueHandling.Ignore)]
        public string OgTitle { get; set; }

        [JsonProperty("og_description", NullValueHandling = NullValueHandling.Ignore)]
        public string OgDescription { get; set; }

        [JsonProperty("twitter_image", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterImage { get; set; }

        [JsonProperty("twitter_title", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterTitle { get; set; }

        [JsonProperty("twitter_description", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterDescription { get; set; }

        [JsonProperty("meta_title", NullValueHandling = NullValueHandling.Ignore)]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_description", NullValueHandling = NullValueHandling.Ignore)]
        public string MetaDescription { get; set; }
    }
}
