namespace Comp7211GroupProject.Classes.API.Models
{
    public interface IMessages
    {
        int Id { get; set; }
        string Msg { get; set; }
        Users Receiver { get; set; }
        int ReceiverId { get; set; }
        Users Sender { get; set; }
        int SenderId { get; set; }
    }
}