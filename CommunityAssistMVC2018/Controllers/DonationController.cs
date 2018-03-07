using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["personKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "Must be logged in to donate";
                return RedirectToAction("Result", m);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, Date, Amount, " +
                                        "ConfirmationCode")]Donate d)
        {
            Donation pd = new Donation();
            pd.PersonKey = d.PersonKey;
            pd.DonationDate = d.Date;
            pd.DonationAmount = d.Amount;
            pd.DonationConfirmationCode = Guid.NewGuid();
            db.Donations.Add(pd);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Thank you for your donation!";

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}