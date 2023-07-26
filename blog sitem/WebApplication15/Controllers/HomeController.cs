using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        public BlogDBContext db = new BlogDBContext();
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x=>x.BlogID);
            ViewBag.İletisim = db.İletisim.SingleOrDefault();
            
            
            return View();
        }
        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
            //en son eklediğimiz slider ı ilk başta görmek istiyorum.
        }
        public ActionResult BlogPartial()
        {
            return View(db.Blog.ToList().OrderByDescending(x => x.BlogID));
        }
        /*public ActionResult Hakkimizda()
        {
            return View(db.Hakkimizda.SingleOrDefault());
        }*/
        //[HttpPost]
        //public ActionResult İletisim(string adsoyad=null, string email=null, string konu=null, string mesaj=null)
        //{
        //    if(adsoyad!=null && email!=null)
        //    {
        //        WebMail.SmtpServer = "smtp.gmail.com";
        //        WebMail.EnableSsl = true;//güvwnli bağlantı
        //        WebMail.UserName = "zhrba06@gmail.com";
        //        WebMail.Password = "123456789";
        //        WebMail.SmtpPort = 587;
        //        WebMail.Send("zhrba06@gmail.com", konu, email + "</br>" + mesaj);
        //        ViewBag.Uyari = ("Mesajınız başarıyla gönderildi");
        //    }
        //    else
        //    {
        //        ViewBag.Uyari = "Hata oluştu.Tekrar deneyiniz!";
        //    }
        //    return View(db.İletisim.SingleOrDefault());
        //}
        public ActionResult Blog()
        {
            return View(db.Blog.Include("Kategori").ToList().OrderByDescending(x => x.BlogID));
               
        }
        public ActionResult BlogDetay(int id)
        {
            var b = db.Blog.Include("Kategori").Where(x => x.BlogID == id).SingleOrDefault();
            return View(b);
        }
    }
}