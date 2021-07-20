using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroAlumnos.Controllers
{
    public class MateriasController : Controller
    {
        
            private RegistroEntities1 db = new RegistroEntities1();
            public ActionResult Index()
            {
                var data = db.mat_materia.ToList();
                return View(data);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryTokenAttribute]
            public ActionResult Create([Bind(Include = "mat_nombre")] mat_materia Materia)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.mat_materia.Add(Materia);
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
                var data = db.mat_materia.Where(b => b.mat_id == id).SingleOrDefault();
                return View(data);
            }

            [HttpPost]
            [ValidateAntiForgeryTokenAttribute]
            public ActionResult Edit(int id, mat_materia Materia)
            {
                var data = db.mat_materia.FirstOrDefault(b => b.mat_id == id);

                if (data != null)
                {
                    data.mat_nombre = Materia.mat_nombre;
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
            public ActionResult Delete(int id, mat_materia Materia)
            {
                var data = db.mat_materia.FirstOrDefault(b => b.mat_id == id);

                if (data != null)
                {
                    db.mat_materia.Remove(data);
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
                var data = db.mat_materia.FirstOrDefault(b => b.mat_id == id);
                return View(data);
            }


        }
    }

