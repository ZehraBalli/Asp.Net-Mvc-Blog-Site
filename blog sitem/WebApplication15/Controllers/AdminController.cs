using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;

namespace WebApplication15.Controllers
{
    public class AdminController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta == admin.Eposta && login.Sifre == admin.Sifre)
            {
                Session["adminid"] = login.AdminID;
                Session["eposta"] = login.Eposta;//bir oturum değişkeni oluşturdum session la
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı Adı veya Yanlış Şifre";
                return View(admin);
            }
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}