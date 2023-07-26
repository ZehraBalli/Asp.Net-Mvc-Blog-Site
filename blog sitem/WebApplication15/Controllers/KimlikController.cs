using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;

namespace WebApplication15.Controllers
{
    public class KimlikController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

       

       

        

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikID == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikID == id).SingleOrDefault();//git bir değer bul ve kimlik bilgisi bu olan değeri getir demek

                if(LogoURL !=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL)))//burda böyle bir dosya var mı diye kontrol ediyorum.varsa silmemiz lazım
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);//isim alıyorum.

                    string logoname = Guid.NewGuid().ToString()+imginfo.Extension;//isim atıyorum.
                    img.Resize(300, 200);//logo boyutuna göre ayarlama yapıyorum.
                    img.Save("~/Uploads/Kimlik/" + logoname);//kaydedilecek yeri ayarladım.

                    k.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                k.Unvan = kimlik.Unvan;
                db.SaveChanges();//kaydetme işlemini yapıyorum burda.
                return RedirectToAction("Index");//mevcut controller ın index action una gitmesini istiyorum.
            }

            return Wiew(kimlik);//bunu yaptım çünkü yoksa yukarıda k kısmındaki hatayı engelliyorum.eğer olmazsa kimlik modelim bana geri dönsün.
        }

        private ActionResult Wiew(Kimlik kimlik)
        {
            throw new NotImplementedException();
        }
    }
}
