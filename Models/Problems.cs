using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasicCSharpRESTful.Models
{
     [JsonObject, Serializable]
     public partial class Problems
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Solution { get; set; }
          public string SolutionLink { get; set; }
          public string Details { get; set; }
     }

     [JsonObject, Serializable]
     public partial class ProblemList
     {
          public List<Problems> problemList = new List<Problems>();
     }
}
