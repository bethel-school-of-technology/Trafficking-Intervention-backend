using System;

namespace Trafficking_Intervention_backend {
    public class LocationEntity {
        public int LocationID {get; set; }
        public string Name {get; set; }
        public string Address {get; set; }
        public string City {get; set; }
        public string State {get; set; }        
        public int ZipCode {get; set; }
        public string LocationType {get; set;}

        
    }
}