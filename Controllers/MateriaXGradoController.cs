using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroAlumnos.Controllers
{
    public class MateriaXGradoController : Controller
    {
        // GET: MateriaXGrado
        private RegistroEntities1 db = new RegistroEntities1();
        public ActionResult Index()
        {
            var data = db.mxg_materiasxgrado.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Create([Bind(Include = "mxg_id_grd,mxg_id_mat")] mxg_materiasxgrado MatGrad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.mxg_materiasxgrado.Add(MatGrad);
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
            var data = db.mxg_materiasxgrado.Where(b => b.mxg_id == id).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Edit(int id, mxg_materiasxgrado MatGrad)
        {
            var data = db.mxg_materiasxgrado.FirstOrDefault(b => b.mxg_id == id);

            if (data != null)
            {
                data.mxg_id_grd = MatGrad.mxg_id_grd;
                data.mxg_id_mat = MatGrad.mxg_id_mat;
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
        public ActionResult Delete(int id, mxg_materiasxgrado MatGrad)
        {
            var data = db.mxg_materiasxgrado.FirstOrDefault(b => b.mxg_id == id);

            if (data != null)
            {
                db.mxg_materiasxgrado.Remove(data);
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
            var data = db.mxg_materiasxgrado.FirstOrDefault(b => b.mxg_id == id);
            return View(data);
        }

    }
}