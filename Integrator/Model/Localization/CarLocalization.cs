using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model.Localization {
    public class CarLocalization : ILocalization {
        public Coordinate Coordinate { get; set; }

        public CarLocalization(Coordinate coordinate) {
            Coordinate = coordinate;
        }
    }
}
