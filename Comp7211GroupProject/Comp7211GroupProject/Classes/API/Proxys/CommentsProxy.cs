using Comp7211GroupProject.Classes.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public class CommentsProxy : ICommentsProxy
    {
        private readonly string _baseAddress;

        public CommentsProxy(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<IComments> GetCommentsByPost(int postID)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Comments/postID={postID}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var comments = response.Content.ReadAsAsync<IComments>();
                if (comments != null)
                {
                    return await comments;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<string> PostComments(Comments comment)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Comments", comment);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeletePost(int id)
        {
            HttpClient http = new HttpClient();

            var response = await http.DeleteAsync($"{_baseAddress}api/Comments/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
