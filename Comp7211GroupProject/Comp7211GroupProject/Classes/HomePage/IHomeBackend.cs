using System.Collections.Generic;
using System.Collections.ObjectModel;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.HomePage
{
    public interface IHomeBackend
    {
        List<Posts> PostList { get; set; }

        void GetPostInfo();
    }
}