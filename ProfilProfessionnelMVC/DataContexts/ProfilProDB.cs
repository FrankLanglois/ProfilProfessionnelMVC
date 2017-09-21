using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProfilProfessionnel.Entities;

namespace ProfilProfessionnelMVC.DataContexts
{
    public class ProfilProDB : DbContext
    {
        public ProfilProDB() : base("ProfilPro")
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Techno> Technos { get; set; }

    }
}