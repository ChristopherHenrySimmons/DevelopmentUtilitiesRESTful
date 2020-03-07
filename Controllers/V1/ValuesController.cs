using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace BasicCSharpRESTful.Controllers
{
          
     public class ValuesController : Controller
     {
          // GET api/v1/values
          [HttpGet("api/v1/GetAllValues")]
          [EnableQuery]
          public ActionResult<IEnumerable<string>> Get()
          {
               return new string[] { "value1", "value2" };
          }

          // GET api/values/5
          [HttpGet("api/v1/GetValueFromId/{id}")]
          public ActionResult<string> Get(int id)
          {
               return "value";
          }

          // POST api/values
          [HttpPost("api/v1/CreateNewValue")]
          public void Post([FromBody] string value)
          {
          }

          // PUT api/values/5
          [HttpPut("api/v1/UpdateValueFromId/{id}")]
          public void Put(int id, [FromBody] string value)
          {
          }

          // DELETE api/values/5
          [HttpDelete("api/v1/DeleteValueFromId/{id}")]
          public void Delete(int id)
          {
          }
     }
}
