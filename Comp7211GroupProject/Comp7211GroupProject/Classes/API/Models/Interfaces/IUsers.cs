using System.Collections.Generic;

namespace Comp7211GroupProject.Classes.API.Models
{
    public interface IUsers
    {
        ICollection<Comments> Comments { get; set; }
        string Dob { get; set; }
        string Email { get; set; }
        string Fname { get; set; }
        int Id { get; set; }
        string Lname { get; set; }
        ICollection<Messages> MessagesReceiver { get; set; }
        ICollection<Messages> MessagesSender { get; set; }
        string Nickname { get; set; }
        string Position { get; set; }
        ICollection<Posts> Posts { get; set; }
        string Pword { get; set; }
        ICollection<Settings> Settings { get; set; }
        string Uid { get; set; }
    }
}