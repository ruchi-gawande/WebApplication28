using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication28.DBModel;
using WebApplication28.Models;

namespace WebApplication28.Controllers
{
    public class HomeController : Controller
    {
        gymEntities objUserDBEntitites = new gymEntities();
        gymEntities5 gymEntities5 = new gymEntities5();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Club()
        // {
        //     return View();
        // }
        public ActionResult Club(string searching)

        {

            return View(objUserDBEntitites.clubs.Where(x => x.Address.Contains(searching) || searching == null).ToList());

        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Gallery()
        {

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Dashboard()
        {

            return View();
        }
        public ActionResult Nutrition()
        {

            return View();
        }

        public ActionResult Membership()
        {

            return View();
        }
        public ActionResult JoinUs()
        {
            joinnow objUserModel = new joinnow();
            return View(objUserModel);
            
        }
        [HttpPost]
        public ActionResult JoinUs(joinnow objUserModel)
        {
            if (ModelState.IsValid)
            {

                if (!gymEntities5.joinnows.Any(m => m.First_Name == objUserModel.First_Name))
                {

                    joinnow objUser = new joinnow();
                    objUser.First_Name = objUserModel.First_Name;
                    objUser.Last_Name = objUserModel.Last_Name;
                    objUser.DOB = objUserModel.DOB;
                    objUser.Gender = objUserModel.Gender;
                    objUser.City= objUserModel.City;
                    objUser.State = objUserModel.State;
                    objUser.Country = objUserModel.Country;
                    objUser.Contact = objUserModel.Contact;
                    objUser.Email_Id = objUserModel.Email_Id;
                   
                    gymEntities5.joinnows.Add(objUser);
                    gymEntities5.SaveChanges();
                    objUserModel = new joinnow();
                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "User already exists with these credentials");
                    
                }
            }
            return View();
        }

      public ActionResult MembershipBenifits()
        {
            return View();
        }
    }
}
