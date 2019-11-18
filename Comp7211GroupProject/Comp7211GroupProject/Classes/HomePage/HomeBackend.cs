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
        private readonly IPostProxy _postProxy;

        //POSTS
        public HomeBackend(IPostProxy postProxy)
        {
            _postProxy = postProxy;
        }

        private ObservableCollection<IPosts> ListOfPosts = new ObservableCollection<IPosts>(){ };//The List for where we will store the data from api
        

        public async void PostInfo()//this method is where the data from the api will be added to thew list
        {
            var allPosts = await _postProxy.GetAllPosts();//gets the data from the API...
            foreach (var item in allPosts)
            {
                ListOfPosts.Add(item);//Adds it to the list
            }
        }

        public ObservableCollection<IPosts> GetPostList
        {
            //the front end will use this method to display whats in the list
            get { return ListOfPosts; }
        }



        //UPVOTES


        

    }
}
