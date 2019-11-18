using Comp7211GroupProject.Classes.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public class PostProxy : IPostProxy
    {
        private readonly string _baseAddress;

        public PostProxy(string baseAddress)
        {
            _baseAddress = baseAddress;
        }


        // Gets all Posts, Returns a list
        // CAN RETURN NULL IF THERE ARE NO POSTS
        public async Task<List<Posts>> GetAllPosts()
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Posts");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var posts = await response.Content.ReadAsAsync<List<Posts>>();
                if (posts != null)
                {
                    return posts;
                }
                else
                    return null;
            }
            else
                return null;
        }

        // Call when posting a post, Takes in a Post class item
        //Returns a string detailing if it was a success or failure
        public async Task<string> PostPosts(Posts post)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Posts", post);
            return await response.Content.ReadAsStringAsync();
        }

        // Call when deleting a Post, takes the postID
        //Returns a string detailing if it was a success or failure
        public async Task<string> DeletePost(int id)
        {
            HttpClient http = new HttpClient();

            var response = await http.DeleteAsync($"{_baseAddress}api/Posts/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
