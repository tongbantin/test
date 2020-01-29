using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vertica.Data.VerticaClient;
namespace Vertica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            using (var db = new VerticaConnection("Host=localhost:37878;Database=docker;User=dbadmin;Password=1234;")) {
                db.Open();
                using (var comm = new VerticaCommand {
                    CommandText = "Select * from TestTable;",
                    Connection = db
                }) {
                    var dt = new DataTable();
                    dt.Load(comm.ExecuteReader());
                   
                }
                db.Close();
            }
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
