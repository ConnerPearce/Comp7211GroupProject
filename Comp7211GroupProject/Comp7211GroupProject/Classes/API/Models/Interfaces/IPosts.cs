using System.Collections.Generic;

namespace Comp7211GroupProject.Classes.API.Models
{
    public interface IPosts
    {
        ICollection<Comments> Comments { get; set; }
        int DownVote { get; set; }
        int Id { get; set; }
        string Post { get; set; }
        Users U { get; set; }
        int Uid { get; set; }
        int UpVote { get; set; }
    }
}