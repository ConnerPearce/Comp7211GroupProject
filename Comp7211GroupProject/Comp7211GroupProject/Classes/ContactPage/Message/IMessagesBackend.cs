using System.Collections.Generic;
using Comp7211GroupProject.Classes.API.Models;

namespace Comp7211GroupProject.Classes.ContactPage.Message
{
    public interface IMessagesBackend
    {
        List<Messages> MessagesList { get; set; }

        void GetMessagesInfo();
    }
}