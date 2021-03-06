﻿using System;
using System.Text;
using System.Collections.Generic;
using Comp7211GroupProject.Classes.API.Models;
using Comp7211GroupProject.Classes.API.Proxys;
using System.Threading.Tasks;

namespace Comp7211GroupProject.Classes.ContactPage.Message
{
    public class MessagesBackend : IMessagesBackend
    {
        // Use for accessing API
        private readonly IMessagesProxy _messagesProxy = new MessagesProxy("https://comp7211groupprojectapi20191115092109.azurewebsites.net/");

        public MessagesBackend()
        {
            GetMessagesInfo();
        }

        public MessagesBackend(IMessagesProxy messagesProxy)
        {
            _messagesProxy = messagesProxy;
            GetMessagesInfo();
        }

        public List<Messages> MessagesList { get; set; } = new List<Messages>();//The List for where we will store the data from api

        public async Task<List<Messages>> GetMessagesInfo()//this code is where the data from the api will be added to thew list
        {
            MessagesList = new List<Messages>();
            var temp = await _messagesProxy.GetMessages(1);
            if (temp != null)
            {
                if (temp.Count > 1)
                {
                    foreach (var item in temp)
                    {
                        MessagesList.Add(item);
                    }
                }
                else
                    MessagesList.Add(temp[0]);
            }
            return MessagesList;

        }

        //The code below is for sending messages

        public async Task<string> SendMessage(string message, int recId)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                var result = await _messagesProxy.PostMessage(new Messages { ReceiverId = recId, SenderId = MainPage.user.Id, Msg = message });
                return result;
            }

            return null;
        }

    }
}