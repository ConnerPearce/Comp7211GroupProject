using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface ISettingsProxy
    {
        Task<ISettings> GetSettings(int userID);
        Task<string> PostSettings(Settings settings);
    }
}