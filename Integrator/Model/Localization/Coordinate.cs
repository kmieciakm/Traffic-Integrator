using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class Coordinate {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinate( double latitude, double longitude ) {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals( object obj ) {
            return obj is Coordinate coordinate &&
                   Latitude == coordinate.Latitude &&
                   Longitude == coordinate.Longitude;
        }

        public override int GetHashCode() {
            var hashCode = -1416534245;
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Longitude.GetHashCode();
            return hashCode;
        }
    }
}
