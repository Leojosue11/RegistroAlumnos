using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroAlumnos.Controllers
{
    public class GradosController : Controller
    {
        // GET: Grados
        private RegistroEntities1 db = new RegistroEntities1();
        public ActionResult Index()
        {
            var data = db.grd_grado.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Create([Bind(Include = "grd_nombre")] grd_grado Grado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.grd_grado.Add(Grado);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Edit(int id)
        {
            var data = db.grd_grado.Where(b => b.grd_id == id).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Edit(int id, grd_grado Grado)
        {
            var data = db.grd_grado.FirstOrDefault(b => b.grd_id == id);

            if (data != null)
            {
                data.grd_nombre = Grado.grd_nombre;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Delete(int id, grd_grado Grado)
        {
            var data = db.grd_grado.FirstOrDefault(b => b.grd_id == id);

            if (data != null)
            {
                db.grd_grado.Remove(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var data = db.grd_grado.FirstOrDefault(b => b.grd_id == id);
            return View(data);
        }


    }
}