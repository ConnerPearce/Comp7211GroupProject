using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface IUserProxy
    {
        Task<IUsers> GetUserInfo(string userID, string pword);
        Task<string> PostUserInfo(Users user);
    }
}