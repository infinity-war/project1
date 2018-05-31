using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}