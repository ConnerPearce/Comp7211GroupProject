using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.HomePage
{
    public class HomeBackend : IHomeBackend
    {
        // Use for accessing API
        private readonly IPostProxy _postProxy = new PostProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");

        public HomeBackend()
	    {
            GetPostInfo();
	    }

        public HomeBackend(IPostProxy postProxy)
        {
            _postProxy = postProxy;
            GetPostInfo();
        }

        public List<Posts> PostList { get; set; } = new List<Posts>();//The List for where we will store the data from api

        public async void GetPostInfo()//this code is where the data from the api will be added to thew list
        {
            PostList = new List<Posts>();

            var temp = await _postProxy.GetAllPosts();
            if (temp != null)
            {
                if (temp.Count > 1)
                {
                    foreach (var item in temp)
                    {
                        PostList.Add(item);
                    }
                }
                else
                    PostList.Add(temp[0]);
            }
        }
    }
}