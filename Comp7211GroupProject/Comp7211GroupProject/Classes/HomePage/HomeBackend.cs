using Comp7211GroupProject.Classes.API.Proxys;
using System;
using System.Collections.Generic;
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
    }
}
