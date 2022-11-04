using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd_BD.Models
{
    public class AlumnoDBContext:DbContext
    {
        private const string ConnectionString = "DefaultConnection";
        public AlumnoDBContext() : base(ConnectionString)
        {
        }

        public DbSet<Alumnos> Alumnos { get; set; } //Dbset es un objeto que nos permite crer una conexion a la base de datos de forma temporal

        public DbSet<Profesor> Profesor { get; set; }
    }


}