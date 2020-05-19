using Integrator.Model.Localization;
using System;

namespace Integrator.Utility {
    public static class Distance {

        // Get Distance in METERS
        public static double LocalizationDistance( ILocalization locOne, ILocalization locTwo ) {
            const double R = 6378.137; // Radius of earth in KM
            var dLat = locTwo.Coordinate.Latitude * Math.PI / 180 - locOne.Coordinate.Latitude * Math.PI / 180;
            var dLon = locTwo.Coordinate.Longitude * Math.PI / 180 - locOne.Coordinate.Longitude * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(locOne.Coordinate.Latitude * Math.PI / 180) *
                Math.Cos(locTwo.Coordinate.Latitude * Math.PI / 180) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d * 1000; // meters
        }
    }

}
