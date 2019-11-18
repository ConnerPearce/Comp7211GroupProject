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

        // Call to recieve messages, returns a list, needs userID (NOT STUDENT ID)
        // WILL RETURN NULL IF THERE IS NO MESSAGES
        public async Task<List<Messages>> GetMessages(int userID)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Messages/userID={userID}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var messages = await response.Content.ReadAsAsync<List<Messages>>();
                if (messages != null)
                {
                    return messages;
                }
                else
                    return null;
            }
            else
                return null;
        }

        // Call to post a message, Takes a message class item
        // Returns a string detailing if it was a success or failure
        public async Task<string> PostMessage(Messages message)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Messages", message);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
