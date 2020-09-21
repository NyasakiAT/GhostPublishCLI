using Jose;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GhostPublishCLI
{
    public class Ghost
    {

        public string TokenId { get; set; }
        public string TokenSecret { get; set; }
        public string AuthToken { get; set; }

        public Ghost(string adminToken)
        {
            string tokenStr = adminToken;

            TokenId = tokenStr.Split(":")[0];
            TokenSecret = tokenStr.Split(":")[1];

            var extraHead = new Dictionary<string, object>()
            {
                { "als", "HS256"},
                { "typ", "JWT"},
                {"kid", TokenId }
            };
            long iat = DateTime.Now.Ticks;
            var payload = new Dictionary<string, object>()
            {
                { "iat", iat},
                { "exp", iat + 5 * 60},
                {"aud", "/v3/admin/" }
            };
            var secretKey = ConvertHexStringToByteArray(TokenSecret);

            AuthToken = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256, extraHead);
        }

        public bool CreatePost(GhostData data, string url)
        {
            HttpClient clientTest = new HttpClient();

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url + "/ghost/api/v3/admin/posts/?source=html"); //with ?source=html mobiledoc is not neccessary

            var serializedJson = Serialize.ToJson(data);

            httpRequest.Content = new StringContent(serializedJson, Encoding.UTF8, "application/json");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Ghost", AuthToken);

            var response = clientTest.SendAsync(httpRequest).Result;

            return response.IsSuccessStatusCode;
        }

        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
    }

}
