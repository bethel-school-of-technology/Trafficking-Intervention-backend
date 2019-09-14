using System;

namespace Trafficking_Intervention_backend {
    public class PrayerRequestEntity {
        public int AppUserID {get; set; }
        public string firstName {get; set; }
        public string lastName {get; set; }
        public string prayer {get; set; }    
          
        public string date {get; set; }
        
        public string sites {get; set; }
        
    }
}