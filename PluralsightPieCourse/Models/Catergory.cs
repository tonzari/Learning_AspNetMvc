﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralsightPieCourse.Models
{
    public class Catergory
    {
        public int CatergoryId { get; set; }
        public string CatergoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
