using System.Collections.Generic;
using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface ICommentsProxy
    {
        Task<List<Comments>> GetCommentsByPost(int postID);
        Task<string> PostComments(Comments comment);
    }
}