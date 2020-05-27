using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class PlaceLocalization : ILocalization {
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }

        [JsonConstructor]
        public PlaceLocalization( string name, Coordinate coordinate ) {
            Name = name;
            Coordinate = coordinate;
        }

        public PlaceLocalization( Coordinate coordinate ) {
            Name = "";
            Coordinate = coordinate;
        }

        public override string ToString() {
            return $"{Name} ({Coordinate.Latitude}, {Coordinate.Longitude})";
        }

        public override bool Equals( object obj ) {
            return obj is PlaceLocalization localization &&
                   Name == localization.Name &&
                   EqualityComparer<Coordinate>.Default.Equals(Coordinate, localization.Coordinate);
        }

        public override int GetHashCode() {
            var hashCode = 1038205281;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Coordinate>.Default.GetHashCode(Coordinate);
            return hashCode;
        }
    }
}
