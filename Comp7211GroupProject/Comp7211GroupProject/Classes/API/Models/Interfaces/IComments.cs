namespace Comp7211GroupProject.Classes.API.Models
{
    public interface IComments
    {
        string Comment { get; set; }
        int Id { get; set; }
        Posts Post { get; set; }
        int PostId { get; set; }
        Users U { get; set; }
        int Uid { get; set; }
    }
}