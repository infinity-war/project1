using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
namespace FirstProject.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login"); 
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            ViewBag.Message = "";
            if (Session["username"] != null)
            {
                Session.Remove("username");
            }
            return RedirectToAction("Login");

        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(signin login, string ReturnUrl = "")
        {
           
            string message = "";
            business operation = new business();
            if(operation.checkLogin(login))
            {
                //var ticket = new FormsAuthenticationTicket(login.username, false, 20);
                //string encrypted = FormsAuthentication.Encrypt(ticket);
                //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                Session["username"] = login.username;
                //var cookie = new HttpCookie("username", login.username);
                //cookie.HttpOnly = true;
                //Response.Cookies.Add(cookie);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                message = "Invalid credential provided";
            }
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.Message = "Your Signup page.";
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User newUser)
        {
            string message = "";
            MDPEntities dc = new MDPEntities();
            if (ModelState.IsValid)
            {
                dc.Users.Add(newUser);
                dc.SaveChanges();
                //var cookie = new HttpCookie("username", newUser.Username);
                //cookie.HttpOnly = true;
                //Response.Cookies.Add(cookie);
                Session["username"] = newUser.Username;
                return RedirectToAction("Index");
            }
            ViewBag.Message = message;
            return View(newUser);
        }

        public ActionResult ViewInfo()
        {
            if (Session["username"] != null)
            {
                return Redirect("~/display.aspx");
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult AddLead()
        {
            
            if (Session["username"] != null)
            {
                MDPEntities dc = new MDPEntities();
                ViewBag.Dropdown = new SelectList(dc.Leads.ToList(), "Id", "Fname");
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult AddLead(Lead i, int? id)
        {
            int? leadId = 0;
            if (id == null)
            {
                MDPEntities dc = new MDPEntities();
                dc.Leads.Add(i);
                dc.SaveChanges();
                leadId = i.Id;
            }
            else
                leadId = id;

            Session["leadId"] = leadId;
            return RedirectToAction("AddInfo");
        }
        public ActionResult AddInfo()
        {

            if (Session["username"] != null)
            {
                
                return View();
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }

        }

        [HttpPost]
        public ActionResult AddInfo(Information info)
        {
            MDPEntities dc = new MDPEntities();
            info.LeadId = Convert.ToInt32(Session["leadId"]);
            dc.Information.Add(info);
            dc.SaveChanges();
            return RedirectToAction("ViewInfo");

        }
        public ActionResult EditInfo(int Id)
        {
            if (Session["username"] != null)
            {
                MDPEntities dc = new MDPEntities();
                Information info = dc.Information.Find(Id);
                ViewBag.Dropdown = new SelectList(dc.Leads.ToList(), "Id", "Fname");
                return View(info);
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public ActionResult EditInfo([Bind(Include = "Id,Salutation,Title,FirstName,BusinessPhone,MobilePhone,FunctionalDepartment,DepartmentRole,Email,InstitutionName1,InstitutionName2,Street1,StreetNo,PostalCode,City,Country,State,OtherComment,LeadOriginator,SourceCampaign,Currency,LeadId")] Information information)
        {
            MDPEntities db = new MDPEntities();
            if (ModelState.IsValid)
            {
               
                db.Entry(information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateInfo");
            }
            ViewBag.Dropdown = new SelectList(db.Leads.ToList(), "Id", "Fname");
            return View(information);

        }

        public ActionResult UpdateInfo()
        {
            if (Session["username"] != null)
            {
                MDPEntities dc = new MDPEntities();
                return View(dc.Information.ToList());
            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult DeleteInfo(int? id)
        {
            if (Session["username"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MDPEntities dc = new MDPEntities();
                Information information = dc.Information.Find(id);
                if (information == null)
                {
                    return HttpNotFound();
                }
                return View(information);

            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }

        }
        // POST: Home/DeleteInfo/5
        [HttpPost, ActionName("DeleteInfo")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["username"] != null)
            {
                MDPEntities db = new MDPEntities();
                Information information = db.Information.Find(id);
                db.Information.Remove(information);
                db.SaveChanges();
                return RedirectToAction("UpdateInfo");

            }
            else
            {
                ViewBag.Message = "Please Login.";
                return RedirectToAction("Login");
            }
            
        }

    }
}