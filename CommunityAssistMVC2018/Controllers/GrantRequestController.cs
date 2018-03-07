using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;
using CommunityAssistMVC2018.Controllers;

namespace CommunityAssistMVC2018.Controllers
{
    public class GrantRequestController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: GrantRequest
        public ActionResult Index()
        {
            if (Session["personKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "You must be logged in to request for a grant.";
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantType = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, ApplicationDate, GrantTypeKey," +
                                   "ApplicationRequestAmount, ApplicationReason, GrantApplicationStatusKey")]GrantRequest gr)
        {
            GrantApplication ga = new GrantApplication();
            gr.PersonKey = (int)Session["personKey"];
            gr.ApplicationDate = ga.GrantAppicationDate;
            gr.GrantTypeKey = ga.GrantTypeKey;
            gr.ApplicationRequestAmount = ga.GrantApplicationRequestAmount;
            gr.ApplicationReason = ga.GrantApplicationReason;
            gr.GrantApplicationStatusKey = ga.GrantApplicationStatusKey;
            db.GrantApplications.Add(ga);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "We understand your need. We will review your request and contact you " +
                            "as soon as we are able to.";

            return View("Result", m);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}