using Comp7211GroupProject.Classes.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public class MessagesProxy : IMessagesProxy
    {
        private readonly string _baseAddress;
        public MessagesProxy(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<IMessages> GetMessages(int userID)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Messages/userID={userID}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var messages = response.Content.ReadAsAsync<IMessages>();
                if (messages != null)
                {
                    return await messages;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<string> PostMessage(Messages message)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Messages", message);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
