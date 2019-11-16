using Comp7211GroupProject.Classes.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public class SettingsProxy : ISettingsProxy
    {
        private readonly string _baseAddress;
        public SettingsProxy(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<ISettings> GetSettings(int userID)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Settings/userID={userID}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var settings = response.Content.ReadAsAsync<ISettings>();
                if (settings != null)
                {
                    return await settings;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<string> PostSettings(Settings settings)
        {
            var http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Settings", settings);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
