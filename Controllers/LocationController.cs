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
    public class LocationController : ControllerBase
    {
        // GET api/Location
        [HttpGet]
        public List<LocationEntity> GetLocations() {

            // Location will be populated with the result of the query.
            List<LocationEntity> Location = new List<LocationEntity>();

            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                // create a string to hold the SQL command.
                string sql = $"select * from locations;";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    
                    // Reader allows you to read each value that comes back from the query and do something to it.
                    using(SqliteDataReader reader = command.ExecuteReader()) {
                        
                        // Loop through query exit when no more objects are left.
                        while (reader.Read()) {

                            // map the data to the Locations model.
                            LocationEntity newLocation = new LocationEntity() {
                                LocationID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                City = reader.GetString(3),
                                State = reader.GetString(4),
                                ZipCode = reader.GetInt32(5),
                                LocationType = reader.GetString(6)
                            };

                            // Add one to the list.
                            Location.Add(newLocation);
                        }
                    }
                }
                // close the connection
                conn.Close();
            }
            return Location;
        }

        // // GET api/Location/user
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // POST api/Location
        [HttpPost]
        public void PostLocation([FromBody] LocationEntity postLocation)
        {

            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                
                string sql = $"insert into locations (Name, Address, City, State, ZipCode, LocationType) values (\"{postLocation.Name}\", \"{postLocation.Address}\", \"{postLocation.City}\", \"{postLocation.State}\", \"{postLocation.ZipCode}\", \"{postLocation.LocationType}\");";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    command.ExecuteNonQuery();
                }
                // close the connection
                conn.Close();
            }
            return;           
        }

        // PUT api/Location/"named-put"
        [HttpPut]
        public void Put([FromBody] LocationEntity putLocation)
        {

            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                
                string sql = $"update locations set Name = \"{putLocation.Name}\", Address = \"{putLocation.Address}\", City = \"{putLocation.City}\", State = \"{putLocation.State}\", ZipCode = \"{putLocation.ZipCode}\", LocatioType = \"{putLocation.LocationType}\"  where Name = \"{putLocation.Name}\";";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    command.ExecuteNonQuery();
                }
                // close the connection
                conn.Close();
            }
            return;
        }

        // DELETE api/Location/"named-delete"
        [HttpDelete]
        public void Delete([FromBody] LocationEntity dropLocation)
        {
            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                
                string sql = $"delete from locations where Name = \"{dropLocation.Name}\";";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    command.ExecuteNonQuery();
                }
                // close the connection
                conn.Close();
            }
            return;
        }
    }
}
