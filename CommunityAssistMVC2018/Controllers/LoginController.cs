using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include =
            "UserName, Password")]LoginClass lc)
        {
            //invoke the database
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();

            //creating login proceedure 
            int loginResult = db.usp_Login(lc.UserName,
            lc.Password);
            
            //login logic
            if(loginResult != -1)
            {
                var uid = (from reg in db.People
                           where reg.PersonEmail.Equals(lc.UserName)
                           select reg.PersonKey).FirstOrDefault();

                //casting uid to an int
                int pKey = (int)uid;
                Session["personKey"] = pKey;

                //creating a automated feedback message
                Message msg = new Message();
                msg.MessageText = "Thank you, " + lc.UserName
                   + " for logging in. You can now donate or apply for" +
                   " assistance.";
                return RedirectToAction("Result", msg);
            }

            Message msg1 = new Message();
            msg1.MessageText = "Invalid Login";
            return View("Result", msg1);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
            }
    }
}