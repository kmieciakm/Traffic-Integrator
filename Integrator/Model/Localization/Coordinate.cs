using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class Coordinate {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public Coordinate( decimal longitude, decimal latitude ) {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
