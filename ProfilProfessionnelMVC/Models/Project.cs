using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfilProfessionnel.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Descrîption { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
    }
}