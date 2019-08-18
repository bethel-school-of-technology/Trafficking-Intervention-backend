using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Trafficking_Intervention_App;

namespace Trafficking_Intervention_App.Controllers {
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]
    public class DatabaseController : Controller {

        // api/database
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
        public List<Testimony> GetTestimonies() {

            // testimonies will be populated with the result of the query.
            List<Testimony> testimonies = new List<Testimony>();

            // GetFullPath will complete the path for the file named passed in as a string.
            string dataSource = "Data Source=" + Path.GetFullPath("traff-int-app.db");

            // Initialize the connection to the .db file.
            using(SqliteConnection conn = new SqliteConnection(dataSource)) {
                conn.Open();
                // create a string to hold the SQL command.
                string sql = $"select * from testimonies;";

                // create a new SQL command by combining the location and command string.
                using(SqliteCommand command = new SqliteCommand(sql, conn)) {
                    
                    // Reader allows you to read each value that comes back from the query and do something to it.
                    using(SqliteDataReader reader = command.ExecuteReader()) {
                        
                        // Loop through query exit when no more objects are left.
                        while (reader.Read()) {

                            // map the data to the Testimony model.
                            Testimony newTestimony = new Testimony() {
                                AppUserID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Testimonies = reader.GetString(3),
                                Date = reader.GetDateTime(4),
                                Sites = reader.GetString(5)
                            };

                            // Add one to the list.
                            testimonies.Add(newTestimony);
                        }
                    }
                }
                // close the connection
                conn.Close();
            }
            return testimonies;

        }
    }
}