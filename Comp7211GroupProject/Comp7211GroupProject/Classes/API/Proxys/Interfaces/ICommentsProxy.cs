using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface ICommentsProxy
    {
        Task<IComments> GetCommentsByPost(int postID);
        Task<string> PostComments(Comments comment);
    }
}