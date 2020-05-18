using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model {
    public class CarData : ICarData {
        public CarLocalization Localization { get; set; }
        public float Speed { get; set; }

        public CarData( CarLocalization localization, float speed ) {
            Localization = localization;
            Speed = speed;
        }
    }
}
