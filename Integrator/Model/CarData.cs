using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model {
    public class CarData : ICarData {
        public CarLocalization Localization { get; set; }
        public double Speed { get; set; }

        public CarData( CarLocalization localization, double speed ) {
            Localization = localization;
            Speed = speed;
        }

        public override string ToString() {
            return Localization.ToString() + $" / Speed: {Speed} mph";
        }

        public override int GetHashCode() {
            var hashCode = -976866304;
            hashCode = hashCode * -1521134295 + EqualityComparer<CarLocalization>.Default.GetHashCode(Localization);
            hashCode = hashCode * -1521134295 + Speed.GetHashCode();
            return hashCode;
        }

        public override bool Equals( object obj ) {
            return obj is CarData data &&
                   EqualityComparer<CarLocalization>.Default.Equals(Localization, data.Localization) &&
                   Speed == data.Speed;
        }
    }
}
