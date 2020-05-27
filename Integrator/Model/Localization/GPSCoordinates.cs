using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class GPSCoordinates {
        public GPSLocalization Latitude { get; set; }
        public GPSLocalization Longitude { get; set; }

        public GPSCoordinates( GPSLocalization latitude, GPSLocalization longitude ) {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
