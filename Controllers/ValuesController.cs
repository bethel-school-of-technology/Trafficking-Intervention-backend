using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.IO;

namespace Trafficking_Intervention_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public List<PrayerRequest> GetPrayerRequests() {

            // prayerRequests will be populated with the result of the query.
            List<PrayerRequest> prayerRequests = new List<PrayerRequest>();

            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                // create a string to hold the SQL command.
                string sql = $"select * from prayer_requests;";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    
                    // Reader allows you to read each value that comes back from the query and do something to it.
                    using(SqliteDataReader reader = command.ExecuteReader()) {
                        
                        // Loop through query exit when no more objects are left.
                        while (reader.Read()) {

                            // map the data to the prayerRequests model.
                            PrayerRequest newPrayerRequest = new PrayerRequest() {
                                AppUserID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                PrayerRequests = reader.GetString(3),
                                Date = reader.GetDateTime(4),
                                Sites = reader.GetString(5)
                            };

                            // Add one to the list.
                            prayerRequests.Add(newPrayerRequest);
                        }
                    }
                }
                // close the connection
                conn.Close();
            }
            return prayerRequests;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
