﻿using System;
using System.Collections.Generic;

namespace DevelopmentUtilitiesRESTful.Models
{
    public partial class ProblemsV2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Solution { get; set; }
        public string SolutionLink { get; set; }
        public string Details { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
