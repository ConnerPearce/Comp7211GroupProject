﻿using System;
using System.Collections.Generic;
using System.Text;
using Comp7211GroupProject.Classes.API.Proxys;

namespace Comp7211GroupProject.Classes.API.Models
{
    public class Messages : IMessages
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Msg { get; set; }

        // Below was generated by scaffolding to represent our Foreign Keys
        // DO NOT REMOVE. THE DB CONTEXT USES THEM

        public virtual Users Receiver { get; set; }
        public virtual Users Sender { get; set; }
    }
}