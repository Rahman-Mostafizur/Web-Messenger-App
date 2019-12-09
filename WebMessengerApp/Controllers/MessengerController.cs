using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMessengerApp.Controllers
{
    public class MessengerController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}