using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.LoginPage
{
    public interface ILoginBackend
    {
        string CheckInfo(string uName, string pwrd);
        Task<IUsers> Login(string uName, string pwrd);
    }
}