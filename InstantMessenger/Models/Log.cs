using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstantMessenger.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

    }


    public class MessageContext:DbContext
    {
        public DbSet<Log> Logs { get; set; }        

        public MessageContext():base("LogContext")
        {
        }
    }
}