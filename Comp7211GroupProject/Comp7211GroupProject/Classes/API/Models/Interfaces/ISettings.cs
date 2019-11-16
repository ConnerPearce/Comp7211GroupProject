namespace Comp7211GroupProject.Classes.API.Models
{
    public interface ISettings
    {
        string AppTheme { get; set; }
        int Id { get; set; }
        Users U { get; set; }
        int Uid { get; set; }
    }
}