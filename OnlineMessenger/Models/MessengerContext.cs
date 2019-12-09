
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineMessenger.Models
{
    public class MessengerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }

        public MessengerContext() : base("MessengerContext")
        {

        }

    }
}