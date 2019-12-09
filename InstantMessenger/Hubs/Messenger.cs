using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstantMessenger.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace InstantMessenger.Hubs
{
    [HubName("Messenger")]
    public class MessengerHub : Hub
    {
        private MessageContext db = new MessageContext();


        [HubMethodName("GetLog")]
        public void GetOldMessages()
        {
            try
            {
                List<Log> logData = db.Logs.ToList();
                Clients.Caller.ReceiveLog(logData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HubMethodName("SendMessage")]
        public void SendPublicMessage(string user, string message)
        {
            try
            {
                #region Store to db
                Log log = new Log()
                {
                    Sender = user,
                    Content = message
                };

                db.Logs.Add(log);
                db.SaveChanges();
                #endregion

                //Clients.All.Receive(user, message);
                Clients.All.Receive(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        [HubMethodName("SendFile")]
        public void SendFile(string user, byte[] file)
        {
            try
            {
                //#region Store to db
                //Log log = new Log()
                //{
                //    Sender = user,
                //    Content = message
                //};

                //db.Logs.Add(log);
                //db.SaveChanges();
                //#endregion

                //Clients.All.Receive(user, message);
                Clients.All.ReceiveFile(user,file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}