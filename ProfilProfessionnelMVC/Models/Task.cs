﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfilProfessionnel.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
    }
}