using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GhostPublishCLI
{
    public class MdFile
    {
        public static Post ParseHeaderToPost(string header)
        {
            Regex r = new Regex(@"(\w*.*:\s*.*)");
            var matches = r.Matches(header);

            var headerDictionary = new Dictionary<string, string>();

            foreach (Match match in matches)
            {
                try
                {
                    var kvPair = match.Value.Split(":");
                    headerDictionary.Add(kvPair[0].Trim(), kvPair.Skip(1).Aggregate((a,b) => a + ":" + b).Trim());
                }
                catch (Exception)
                {
                    throw new Exception("Header wrong formatted!");
                }
            }

            return FillPostObject(headerDictionary);
        }

        private static Post FillPostObject(Dictionary<string, string> headerDictionary)
        {
            return new Post()
            {
                Authors = headerDictionary.ContainsKey("authors") ? headerDictionary["authors"].Split(";") : null,
                CustomExcerpt = headerDictionary.ContainsKey("excerpt") ? headerDictionary["excerpt"] : null,
                FeatureImage = headerDictionary.ContainsKey("image") ? new Uri(headerDictionary["image"]) : null,
                MetaDescription = headerDictionary.ContainsKey("meta_description") ? headerDictionary["meta_description"] : null,
                MetaTitle = headerDictionary.ContainsKey("meta_title") ? headerDictionary["meta_title"] : null,
                Title = headerDictionary["title"],
                OgImage = headerDictionary.ContainsKey("image") ? headerDictionary["image"] : null,
                OgDescription = headerDictionary.ContainsKey("excerpt") ? headerDictionary["excerpt"] : null,
                OgTitle = headerDictionary["title"],
                TwitterImage = headerDictionary.ContainsKey("image") ? headerDictionary["image"] : null,
                TwitterDescription = headerDictionary.ContainsKey("excerpt") ? headerDictionary["excerpt"] : null,
                TwitterTitle = headerDictionary["title"],
                Status = headerDictionary.ContainsKey("status") ? headerDictionary["status"] : null,
                Tags = headerDictionary.ContainsKey("tags") ? headerDictionary["tags"].Split(";") : null,
                Slug = headerDictionary.ContainsKey("slug") ? headerDictionary["slug"] : null,
            };
        }
    }
}
