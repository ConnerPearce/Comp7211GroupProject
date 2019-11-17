using System.Collections.Generic;
using System.Threading.Tasks;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.API.Proxys
{
    public interface IPostProxy
    {
        Task<List<IPosts>> GetAllPosts();
        Task<string> PostPosts(Posts post);
    }
}