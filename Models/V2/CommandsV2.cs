using System;
using System.Collections.Generic;

namespace DevelopmentUtilitiesRESTful.Models
{
    public partial class CommandsV2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Command { get; set; }
        public string ConsoleType { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
