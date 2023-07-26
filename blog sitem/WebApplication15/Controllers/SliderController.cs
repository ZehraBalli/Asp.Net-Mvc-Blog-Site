using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;

namespace WebApplication15.Controllers
{
    public class SliderController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: Sliders
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Baslik,Aciklama,ResimURL")] Slider slider,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {

                    WebImage img = new WebImage(ResimURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);//isim alıyorum.

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;//isim atıyorum.
                    img.Resize(1280, 720);//resim boyutuna göre ayarlama yapıyorum.
                    img.Save("~/Uploads/Slider/" + sliderimgname);//kaydedilecek yeri ayarladım.

                    slider.ResimURL = "/Uploads/Slider/" + sliderimgname;
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,Baslik,Aciklama,ResimURL")] Slider slider,HttpPostedFileBase ResimURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();//tek bir kayıt olacağı için singleordefault diyorum ve id eşleştirmesi yapıyorum.
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.ResimURL)))//yukarıdaki sorguda kayıt var mı bak
                    {
                        System.IO.File.Delete(Server.MapPath(s.ResimURL));//eğer varsa o kaydı sil.
                    }
                    WebImage img = new WebImage(ResimURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);//isim alıyorum.

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;//isim atıyorum.
                    img.Resize(1024, 360);//logo boyutuna göre ayarlama yapıyorum.
                    img.Save("~/Uploads/Slider/" + sliderimgname);//kaydedilecek yeri ayarladım.

                    s.ResimURL = "/Uploads/Slider/" + sliderimgname;//kaydı güncelledik.
                }
                s.Baslik = slider.Baslik;
                s.Aciklama = slider.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            if (System.IO.File.Exists(Server.MapPath(slider.ResimURL)))//yukarıdaki sorguda kayıt var mı bak
            {
                System.IO.File.Delete(Server.MapPath(slider.ResimURL));//eğer varsa o kaydı sil.
            }
            db.Slider.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
