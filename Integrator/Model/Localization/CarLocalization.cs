using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class CarLocalization : ILocalization {
        public Coordinate Coordinate { get; set; }

        public CarLocalization(Coordinate coordinate) {
            Coordinate = coordinate;
        }

        public override string ToString() {
            return $"Localization: ({Coordinate.Latitude}, {Coordinate.Longitude})";
        }

        public override bool Equals( object obj ) {
            return obj is CarLocalization localization &&
                   EqualityComparer<Coordinate>.Default.Equals(Coordinate, localization.Coordinate);
        }

        public override int GetHashCode() {
            return -1638168797 + EqualityComparer<Coordinate>.Default.GetHashCode(Coordinate);
        }
    }
}
