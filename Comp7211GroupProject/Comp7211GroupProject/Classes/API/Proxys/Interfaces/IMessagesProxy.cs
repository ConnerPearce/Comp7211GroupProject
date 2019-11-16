using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface IMessagesProxy
    {
        Task<IMessages> GetMessages(int userID);
        Task<string> PostMessage(Messages message);
    }
}