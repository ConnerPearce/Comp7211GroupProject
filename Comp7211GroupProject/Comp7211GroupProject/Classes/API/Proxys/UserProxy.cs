using Comp7211GroupProject.Classes.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public class UserProxy : IUserProxy
    {
        private readonly string _baseAddress;

        public UserProxy(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        // Call when getting user info, takes the userID (STUDENT ID) and a password
        // CAN RETURN NULL IF THE USER DOESNT EXIST OR THERE IS AN ERROR
        public async Task<IUsers> GetUserInfo(string userID, string pword)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Users/userID={userID}&Password={pword}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var user = response.Content.ReadAsAsync<Users>();
                if (user != null)
                {
                    return await user;
                }
                else
                    return null;
            }
            else
                return null;
        }

        // Used to update user info - i.e. nickname
        // Returns a string detailing if it was a success or failure
        public async Task<string> PostUserInfo(Users user)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Users", user);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
