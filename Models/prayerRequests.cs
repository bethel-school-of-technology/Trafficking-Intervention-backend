using System;

namespace Trafficking_Intervention_App {
    public class PrayerRequest {
        public int AppUserID {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string PrayerRequests {get; set; }
        
        public DateTime Date {get; set; }
        
        public string Sites {get; set; }
        
    }
}