using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasicCSharpRESTful.Models
{
     [JsonObject, Serializable]
     public partial class Commands
     {
          public int Id { get; set; }
          public string Tile { get; set; }
          public string Command { get; set; }
          public string ConsoleType { get; set; }
     }

     [JsonObject, Serializable]
     public partial class CommandList
     {
          public List<Commands> commandList = new List<Commands>();
     }
}
