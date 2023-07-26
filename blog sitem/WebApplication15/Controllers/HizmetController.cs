using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;


namespace WebApplication15.Controllers
{
    public class HizmetController : Controller
    {
        //BlogDBContext db = new BlogDBContext();
        //private object context;
        //private object eve;

        //// GET: Hizmet
        //public ActionResult Index()
        //{
        //    return View(db.Hizmet.ToList());
        //}


        //public ActionResult Create()//veritabanına veri kaydediyoruz.
        //{
        //    {
        //        return View();
        //    }
        //}
        //[HttpPost]
        
        //[ValidateInput(false)]
        //public ActionResult Create(Hizmet hizmet,HttpPostedFileBase ResimURL)//veritabanına veri kaydediyoruz.
        //{
        //    {
        //        if(ModelState.IsValid)//resim kısmını oluşturdum
        //        {
                   
        //            if (ResimURL != null)
        //            {
                        
        //                WebImage img = new WebImage(ResimURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
        //                FileInfo imginfo = new FileInfo(ResimURL.FileName);//isim alıyorum.

        //                string logoname = Guid.NewGuid().ToString() + imginfo.Extension;//isim atıyorum.
        //                img.Resize(500, 500);//logo boyutuna göre ayarlama yapıyorum.
        //                img.Save("~/Uploads/Hizmet/" + logoname);//kaydedilecek yeri ayarladım.

        //                hizmet.ResimURL = "/Uploads/Hizmet/" + logoname;
        //            }

                  

                   
        //            db.SaveChanges();//kaydetme işlemini yapıyorum burda. // your code goes here...

        //            return RedirectToAction("Index");//mevcut controller ın index action una gitmesini istiyorum.



        //        }
        //        return View(hizmet);
        //    }
        }
    }


