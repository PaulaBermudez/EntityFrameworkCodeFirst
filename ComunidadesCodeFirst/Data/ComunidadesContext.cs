using ComunidadesCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ComunidadesCodeFirst.Data
{
    public class ComunidadesContext:DbContext
    {
        public ComunidadesContext() : base("name=cadenacomunidades") { }
        public DbSet<Comunidad> Comunidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}