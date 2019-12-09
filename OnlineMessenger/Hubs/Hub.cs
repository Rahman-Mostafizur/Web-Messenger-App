using Microsoft.AspNet.SignalR;
using OnlineMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OnlineMessenger.Hubs
{
    [Authorize]
    public class MessengerHub:Hub
    {
        private readonly MessengerContext db = new MessengerContext();

         [Authorize]
        public override Task OnConnected()
        {
            //Interlocked.Increment(ref _usersCount);
            
            User user = db.Users.First(r=>r.Email== HttpContext.Current.User.Identity.Name);
            user.ConnectionId=Context.ConnectionId;
            db.Entry(user).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return base.OnConnected();
        }

        public void GetMessages()
        {
            User user = db.Users.First(r => r.ConnectionId == Context.ConnectionId);
            

            var messages = db.MessageLogs.ToList();
            Clients.All.ReceiveLog( messages);



        }



        //send public message
        public void SendMessage( string message)
        {
            User user = db.Users.First(r=>r.ConnectionId== Context.ConnectionId);

            MessageLog msgLog = new MessageLog()
            {

                Sender = user.Email,
                Content=message,
                Recipient ="All",

                RecipientType=RecipientType.All

            };


            db.MessageLogs.Add(msgLog);
            db.SaveChanges();
            Clients.All.Receive(user.Email, message);



        }


    }
}