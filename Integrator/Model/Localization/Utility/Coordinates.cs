using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization.Utility {
    public static class Coordinates {

        public static Coordinate GPSToLatLong( GPSCoordinates gps ) {
            const int accuracy = 5;

            double latitude = 0;
            latitude += gps.Latitude.Degree
                + gps.Latitude.Minute / 60
                + gps.Latitude.Second / 3600;
            if (gps.Latitude.Compass == Compass.South) {
                latitude *= -1;
            }
            latitude = Math.Round(latitude, accuracy);

            double longitude = 0;
            longitude += gps.Longitude.Degree
                + gps.Longitude.Minute / 60
                + gps.Longitude.Second / 3600;
            if (gps.Longitude.Compass == Compass.West) {
                longitude *= -1;
            }
            longitude = Math.Round(longitude, accuracy);

            return new Coordinate(latitude, longitude);
        }
    }
}
