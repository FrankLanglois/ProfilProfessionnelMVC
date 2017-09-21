using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfilProfessionnel.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool IsCurrentCompany { get; set; }

  
    }
}