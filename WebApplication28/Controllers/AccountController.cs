using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication28.DBModel;
using WebApplication28.Models;

namespace WebApplication28.Controllers
{
    public class AccountController : Controller
    {

        gymEntities1 objUserDBEntitites = new gymEntities1();
        gymEntities3 objAdminDBEntities = new gymEntities3();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {

                if (!objUserDBEntitites.Registrations.Any(m => m.username == objUserModel.username))
                {

                    Registration objUser = new DBModel.Registration();
                    objUser.userid = objUserModel.userid;
                    objUser.username = objUserModel.username;
                    objUser.age = objUserModel.age;
                    objUser.email = objUserModel.email;
                    objUser.address = objUserModel.address;
                    objUser.city = objUserModel.city;
                    objUser.state = objUserModel.state;
                    objUser.country = objUserModel.country;
                    objUser.gender = objUserModel.gender;
                    objUser.contact = objUserModel.contact;
                    objUserDBEntitites.Registrations.Add(objUser);
                    objUserDBEntitites.SaveChanges();
                    objUserModel = new UserModel();
                    objUserModel.Success = "successfully registered";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "User already exists with these credentials");
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();

            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objUserDBEntitites.Registrations.Where(m => m.username == objLoginModel.username && m.email == objLoginModel.email).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "User Name and Email Id is not matching");
                    return View();
                }
                else
                {
                    Session["username"] = objLoginModel.username;
                    return RedirectToAction("Membership", "Home");
                }

            }
            return View();
        }
        public ActionResult LoginAdmin()
        {
            Models.Admin objAdmin = new Models.Admin();

            return View(objAdmin);
        }
        [HttpPost]
        public ActionResult LoginAdmin(Models.Admin objAdmin)
        {
            if (ModelState.IsValid)
            {
                if (objAdminDBEntities.Admins.Where(m => m.admin_id == objAdmin.admin_id && m.username == objAdmin.username).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalild credentials");
                    return View();
                }
                else
                {
                    Session["admin_id"] = objAdmin.admin_id;

                    return RedirectToAction("Dashboard", "Home");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Photo()
        {
            return View();
        }


        //    [HttpGet]
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult Create(Registration registration)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            RegisterDBHandler dBHandler = new RegisterDBHandler();
        //            if (dBHandler.InsertUser(registration))
        //            {
        //                ViewBag.Message = "User Added";
        //                ModelState.Clear();
        //            }
        //        }
        //        return View();
        //    }
        //    [HttpGet]
        //    public ActionResult Edit(int id)
        //    {
        //        RegisterDBHandler dBHandler = new RegisterDBHandler();
        //        return View(dBHandler.GetUsers().Find(Registration => Registration.userid == id));
        //    }
        //    [HttpPost]
        //    public ActionResult Edit(int id, Registration registration)
        //    {
        //        RegisterDBHandler dBHandler = new RegisterDBHandler();
        //        dBHandler.updateUser(registration);
        //        return RedirectToAction("Index");
        //    }

        //    public ActionResult Delete(int id)
        //    {
        //        RegisterDBHandler dBHandler = new RegisterDBHandler();
        //        if (dBHandler.DelUser(id))
        //        {
        //            ViewBag.msg = "User has been deleted";
        //        }
        //        RedirectToAction("Index");
        //        return View();
        //    }
        //    public ActionResult Details(int id)
        //    {
        //        RegisterDBHandler dBHandler = new RegisterDBHandler();
        //        return View(dBHandler.GetUsers().Find(Registration => Registration.userid == id));
        //    }
        //}
    }
}
