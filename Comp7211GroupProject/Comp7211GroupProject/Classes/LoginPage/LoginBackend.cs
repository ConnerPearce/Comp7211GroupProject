using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.LoginPage
{
    public class LoginBackend : ILoginBackend
    {
        private readonly IUserProxy _userProxy;

        public LoginBackend(IUserProxy userProxy)
        {
            _userProxy = userProxy;
        }

        public string CheckInfo(string uName, string pwrd)
        {
            if (String.IsNullOrWhiteSpace(uName))
                return "Username can not be empty";
            else if (String.IsNullOrWhiteSpace(pwrd))
                return "Password can not be empty";
            else
                return null;
        }

        public async Task<IUsers> Login(string uName, string pwrd)
        {
            return await _userProxy.GetUserInfo(uName, pwrd);
        }
    }
}
