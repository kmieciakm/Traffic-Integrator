using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class GPSLocalization {
        public double Degree { get; set; }
        public double Minute { get; set; }
        public double Second { get; set; }
        public Compass Compass { get; set; }

        public GPSLocalization( double degree, double minute, double second, Compass compass ) {
            Degree = degree;
            Minute = minute;
            Second = second;
            Compass = compass;
        }

        public override bool Equals( object obj ) {
            return obj is GPSLocalization coordinate &&
                   Degree == coordinate.Degree &&
                   Minute == coordinate.Minute &&
                   Second == coordinate.Second &&
                   Compass == coordinate.Compass;
        }

        public override int GetHashCode() {
            var hashCode = 1964249198;
            hashCode = hashCode * -1521134295 + Degree.GetHashCode();
            hashCode = hashCode * -1521134295 + Minute.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            hashCode = hashCode * -1521134295 + Compass.GetHashCode();
            return hashCode;
        }
    }

    public enum Compass { 
        North,
        South,
        East,
        West
    }

}
