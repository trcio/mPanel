using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace mPanel.Extra.Yahoo
{
    public class YahooProvider : IDisposable
    {
        private const string YqlEndpoint = "https://query.yahooapis.com/v1/public/yql?q={0}&format=json";

        private readonly HttpClient Client;

        public YahooProvider()
        {
            Client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false,
                UseProxy = false
            });
        }

        private async Task<string> GetQuery(string query)
        {
            return await Client.GetStringAsync(string.Format(YqlEndpoint, query));
        }

        public async Task<WeatherResponse> GetWeather(string location)
        {
            var json = await GetQuery($"select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{location}\")");

            return JsonUtil.Deserialize<WeatherResponse>(json);
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
