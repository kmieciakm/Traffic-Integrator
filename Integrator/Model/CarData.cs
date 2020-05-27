using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model {
    public class CarData : ICarData {
        public CarLocalization Localization { get; set; }
        public double Speed { get; set; }
        public PlaceLocalization StartingPoint { get; set; }
        public PlaceLocalization EndingPoint { get; set; }

        public CarData( CarLocalization localization, double speed,
                PlaceLocalization startingPoint, PlaceLocalization endingPoint ) {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Localization = localization;
            Speed = speed;
        }

        public override string ToString() {
            return Localization.ToString() + Environment.NewLine
                + $"Speed: {Speed} mph" + Environment.NewLine
                + $"From: " + StartingPoint.ToString() + Environment.NewLine
                + $"To: " + EndingPoint.ToString() + Environment.NewLine;
        }

        public override bool Equals( object obj ) {
            return obj is CarData data &&
                   EqualityComparer<CarLocalization>.Default.Equals(Localization, data.Localization) &&
                   Speed == data.Speed &&
                   EqualityComparer<PlaceLocalization>.Default.Equals(StartingPoint, data.StartingPoint) &&
                   EqualityComparer<PlaceLocalization>.Default.Equals(EndingPoint, data.EndingPoint);
        }

        public override int GetHashCode() {
            var hashCode = -1502206235;
            hashCode = hashCode * -1521134295 + EqualityComparer<CarLocalization>.Default.GetHashCode(Localization);
            hashCode = hashCode * -1521134295 + Speed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<PlaceLocalization>.Default.GetHashCode(StartingPoint);
            hashCode = hashCode * -1521134295 + EqualityComparer<PlaceLocalization>.Default.GetHashCode(EndingPoint);
            return hashCode;
        }
    }
}
