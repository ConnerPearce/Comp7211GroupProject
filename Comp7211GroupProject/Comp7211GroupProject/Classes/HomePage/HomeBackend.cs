using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Comp7211GroupProject.Classes.HomePage
{
    public class HomeBackend
    {
        // Use for accessing API
        IPostProxy _postProxy;


        public HomeBackend(IPostProxy postProxy)
        {
            _postProxy = postProxy;
        }

        private ObservableCollection<IPosts> PostList = new ObservableCollection<IPosts>(){ };//The List for where we will store the data from api

        public async void PostInfo()//this code is where the data from the api will be added to thew list
        {
            var temp = await _postProxy.GetAllPosts();
            foreach (var item in temp)
            {
                PostList.Add(item);
            }
        }

        public ObservableCollection<IPosts> GetPostList
        {
            //the front end will this method to display whats in the list
            get { return PostList; }
        }


    }
}
