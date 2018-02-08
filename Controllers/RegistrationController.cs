using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class RegistrationController : Controller
    {
        //accessing the CommunityAssist database
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        
        // GET: Registration
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include =
            "LastName, FirstName, " +
            "Email, Password, " +
            "ApartmentNumber, Street, " +
            "City, State, Zipcode, Phone")
            ]NewPerson reg)
        {
            int result = db.usp_Register(
                reg.LastName,
                reg.FirstName, 
                reg.Email,
                reg.PlainPassword, 
                reg.ApartmentNumber, 
                reg.Street, 
                reg.City, 
                reg.State, 
                reg.Zipcode, 
                reg.Phone
                );

            if(result != -1)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}