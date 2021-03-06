﻿using Comp7211GroupProject.Classes.API.Models;
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

        // Use when person views post in detail, Pass through the postID
        // CAN RETURN NULL IF THERE ARE NO COMMENTS
        public async Task<List<Comments>> GetCommentsByPost(int postID)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress)
            };
            var url = String.Format($"api/Comments/postID={postID}");
            HttpResponseMessage response = http.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var comments = await response.Content.ReadAsAsync<List<Comments>>();
                if (comments != null)
                {
                    return comments;
                }
                else
                    return null;
            }
            else
                return null;
        }

        // Called when posting, Takes in a Comment class item
        //Returns a string detailing if it was a success or failure
        public async Task<string> PostComments(Comments comment)
        {
            HttpClient http = new HttpClient();

            var response = await http.PostAsJsonAsync($"{_baseAddress}api/Comments", comment);
            return await response.Content.ReadAsStringAsync();
        }

        // Deleting a post takes in the commentsID
        // Returns a string detailing if it was a success or failure
        public async Task<string> DeleteComment(int id)
        {
            HttpClient http = new HttpClient();

            var response = await http.DeleteAsync($"{_baseAddress}api/Comments/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}