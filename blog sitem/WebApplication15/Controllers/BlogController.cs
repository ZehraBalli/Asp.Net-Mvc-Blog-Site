using System;
using System.Collections.Generic;
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
    public class BlogController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
       




        // GET: Blog
        public ActionResult Index()
        {
            return View(db.Blog.ToList().OrderByDescending(x=>x.BlogID));
        }
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase ResimURL)
        {
            if (ResimURL != null)
            {
               
                WebImage img = new WebImage(ResimURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
                FileInfo imginfo = new FileInfo(ResimURL.FileName);//isim alıyorum.

                string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;//isim atıyorum.
                img.Resize(600, 400);//logo boyutuna göre ayarlama yapıyorum.
                img.Save("~/Uploads/Blog/" + blogimgname);//kaydedilecek yeri ayarladım.

                blog.ResimURL = "/Uploads/Blog/" + blogimgname;
            }
            db.Blog.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            if(id==null)
            {
                return HttpNotFound();//bulamıyorsa hata ver demek
            }
            var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();//sayfaları eşleştirme yaptım
            if (b == null)
            {
                return HttpNotFound();//bulamıyorsa hata ver demek
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", b.KategoriID);

            return View(b);
        }
        //resim güncelletme 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Blog blog, HttpPostedFileBase ResimURL )
        {
            if (ModelState.IsValid)//yani modelimiz doğrulandıysa dmek
            {
                var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();//aynı işlem tine işlem doğruysa o sayfaya eşitliyorum.
                if (ResimURL != null)
                {

                    WebImage img = new WebImage(ResimURL.InputStream); //yoksa resim yükleme işlemini yapıyorum.
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);//isim alıyorum.

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;//isim atıyorum.
                    img.Resize(600, 400);//logo boyutuna göre ayarlama yapıyorum.
                    img.Save("~/Uploads/Blog/" + blogimgname);//kaydedilecek yeri ayarladım.

                    blog.ResimURL = "/Uploads/Blog/" + blogimgname;
                }
                b.Baslik = blog.Baslik;
                b.İcerik = blog.İcerik;
                b.KategoriID = blog.KategoriID;
                db.SaveChanges();
                return RedirectToAction("Index");//geri index sayfasına düşüyoruz.
            }
            return View(blog);
        }
        /*[HttpPost]
        public ActionResult Delete(int id)
        {
            var b = db.Blog.Find(id);///kaydı buldurdum.
            if(b==null)
            {
                return HttpNotFound();
            }
            if(System.IO.File.Exists(Server.MapPath(b.ResimURL)))//yukarıdaki sorguda kayıt var mı bak
            {
                System.IO.File.Delete(Server.MapPath(b.ResimURL));//eğer varsa o kaydı sil.
            }
            db.Blog.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog= db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            if (System.IO.File.Exists(Server.MapPath(blog.ResimURL)))//yukarıdaki sorguda kayıt var mı bak
            {
                System.IO.File.Delete(Server.MapPath(blog.ResimURL));//eğer varsa o kaydı sil.
            }
            db.Blog.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}