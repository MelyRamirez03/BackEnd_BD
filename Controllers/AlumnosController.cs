using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                //select * from alumnos
                return View(dbAlumnos.Alumnos.ToList());
            }

        }
        public ActionResult Details(int id)
        {
            using (AlumnoDBContext dbAlumnos=new AlumnoDBContext())
            {
                Alumnos alumnos = dbAlumnos.Alumnos.Find(id);
                if (alumnos == null)
                {
                    return HttpNotFound();
                }
                return View(alumnos);
            }
              
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

       
        public ActionResult Create(Alumnos alum)
        {
            using(AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                dbAlumnos.Alumnos.Add(alum);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int? id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext()) 
            {
                return View(dbAlumnos.Alumnos.Where(x=>x.Id==id).FirstOrDefault());
            }
        }

        [HttpPost] //Los datos serán mandados por Post, si no tiene ninguno de estos es un Get

        public ActionResult Edit(Alumnos alum)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                dbAlumnos.Entry(alum).State = System.Data.Entity.EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                return View(dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost] //Los datos serán mandados por Post, si no tiene ninguno de estos es un Get

        public ActionResult Delete(Alumnos alum, int id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                Alumnos al = dbAlumnos.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Alumnos.Remove(al);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}