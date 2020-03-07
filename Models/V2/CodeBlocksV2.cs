using System;
using System.Collections.Generic;

namespace DevelopmentUtilitiesRESTful.Models
{
    public partial class CodeBlocksV2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Block { get; set; }
        public string Langue { get; set; }
        public string Function { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
