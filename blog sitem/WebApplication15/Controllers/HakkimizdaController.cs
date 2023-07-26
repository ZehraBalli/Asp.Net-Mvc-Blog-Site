using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models.DataContext;
using WebApplication15.Models.Model;

namespace WebApplication15.Controllers
{
    public class HakkimizdaController : Controller
    {
        BlogDBContext db = new BlogDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaID == id).FirstOrDefault();
            return View(h);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//verilerin gönderilmesiyle ilgili güvenliği sağladım.
        [ValidateInput(false)]
        public ActionResult Edit(int id,Hakkimizda h)
        {
            if(ModelState.IsValid)//modelimiz doğrulandıysa yap demek.
                {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaID == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;//yazılan açıklamayı aktardım
                db.SaveChanges();//veritabanına kaydettim
                return RedirectToAction("Index");//güncelledikten sonra nereye gitmesi gerektiğini söyledim.
            }
            
            return View();
        }
      
    }
}