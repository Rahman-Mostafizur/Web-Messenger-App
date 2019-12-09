using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMessenger.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string AdminUser { get; set; }

    }


    public class UserGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }

}