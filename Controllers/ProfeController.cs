using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class ProfeController : Controller
    {
        public ActionResult Index()
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                //select * from alumnos
                return View(dbAlumnos.Profesor.ToList());
            }

        }
        public ActionResult Details(int id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                Profesor profesor = dbAlumnos.Profesor.Find(id);
                if (profesor == null)
                {
                    return HttpNotFound();
                }
                return View(profesor);
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Create(Profesor profe)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                dbAlumnos.Profesor.Add(profe);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                return View(dbAlumnos.Profesor.Where(x => x.Id == id).FirstOrDefault());
            }
        }


        [HttpPost] //Los datos serán mandados por Post, si no tiene ninguno de estos es un Get

        public ActionResult Edit(Profesor profe)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                dbAlumnos.Entry(profe).State = System.Data.Entity.EntityState.Modified;
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                return View(dbAlumnos.Profesor.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost] //Los datos serán mandados por Post, si no tiene ninguno de estos es un Get

        public ActionResult Delete(Profesor profe, int id)
        {
            using (AlumnoDBContext dbAlumnos = new AlumnoDBContext())
            {
                Profesor prof = dbAlumnos.Profesor.Where(x => x.Id == id).FirstOrDefault();
                dbAlumnos.Profesor.Remove(prof);
                dbAlumnos.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}