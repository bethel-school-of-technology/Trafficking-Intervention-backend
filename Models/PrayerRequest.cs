using System;

namespace Trafficking_Intervention_backend {
    public class PrayerRequestEntity {
        public int AppUserID {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string PrayerRequest {get; set; }    
          
        public string Date {get; set; }
        
        public string Sites {get; set; }
        
    }
}