using System;
using System.Collections.Generic;

namespace DevelopmentUtilitiesRESTful.Models
{
    public partial class ResourcesV2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Langues { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
