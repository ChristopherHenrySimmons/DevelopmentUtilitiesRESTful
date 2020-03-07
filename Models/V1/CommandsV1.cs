using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasicCSharpRESTful.Models
{
     [JsonObject, Serializable]
     public partial class CommandsV1
     {
          public int Id { get; set; }
          public string Title { get; set; }
          public string Command { get; set; }
          public string ConsoleType { get; set; }
     }

     [JsonObject, Serializable]
     public partial class CommandList
     {
          public List<CommandsV1> commandList = new List<CommandsV1>();
     }
}
