using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMessenger.Models
{
    public class MessageLog
    {
        public int Id { get; set; }

        public string Sender { get; set; }
        public string Content { get; set; }

        public string Recipient { get; set; }
        public RecipientType RecipientType { get; set; } = RecipientType.All;

        public DateTime Time { get; set; } = DateTime.Now;

    }


    public enum RecipientType
    {
        Private, Group, All
    }
}