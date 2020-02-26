using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasicCSharpRESTful.Models
{
     [JsonObject, Serializable]
     public partial class Resources
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public string Link { get; set; }
          public string Langues { get; set; }
     }


     public partial class ResourceList
     {
          public List<Resources> resourceList = new List<Resources>();
     }
}
