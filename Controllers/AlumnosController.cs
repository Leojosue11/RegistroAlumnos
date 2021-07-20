using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroAlumnos.Controllers
{
    public class AlumnosController : Controller
    {
            private RegistroEntities1 db = new RegistroEntities1();
            public ActionResult Index()
            {
                var data = db.alm_alumno.ToList();
                return View(data);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryTokenAttribute]
            public ActionResult Create([Bind(Include = "alm_codigo, alm_nombre,alm_edad,alm_sexo,alm_id_grd,alm_observacion")] alm_alumno Alumno)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.alm_alumno.Add(Alumno);
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
                var data = db.alm_alumno.Where(b => b.alm_id == id).SingleOrDefault();
                return View(data);
            }

            [HttpPost]
            [ValidateAntiForgeryTokenAttribute]
            public ActionResult Edit(int id, alm_alumno Alumno)
            {
                var data = db.alm_alumno.FirstOrDefault(b => b.alm_id == id);

                if (data != null)
                {
                    data.alm_codigo = Alumno.alm_codigo;
                    data.alm_nombre = Alumno.alm_nombre;
                    data.alm_edad = Alumno.alm_edad;
                    data.alm_sexo = Alumno.alm_sexo;
                    data.alm_id_grd = Alumno.alm_id_grd;
                    data.alm_observacion = Alumno.alm_observacion;
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
            public ActionResult Delete(int id, alm_alumno Alumno)
            {
                var data = db.alm_alumno.FirstOrDefault(b => b.alm_id == id);

                if (data != null)
                {
                    db.alm_alumno.Remove(data);
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
                var data = db.alm_alumno.FirstOrDefault(b => b.alm_id == id);
                return View(data);
            }


       
    }
}