using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrator.TrafficIntensity {
    public class TrafficIntensity : ITrafficIntensity {
        public List<ICarData> Cars { get; }
        public PlaceLocalization SeedPoint { get; }
        public int Accuracy { get; }

        public TrafficIntensity( PlaceLocalization seedPoint, int accuracy, IEnumerable<ICarData> cars ) {
            SeedPoint = seedPoint;
            Accuracy = accuracy;
            Cars = cars.ToList();
        }

        public int GetCarsAmount() {
            return Cars.Count;
        }

        public IEnumerable<ICarData> GetCars() {
            return Cars.ToList();
        }

        public double GetAverageSpeed() {
            if (Cars.Count() <= 0) {
                return 0.0;
            }
            return Cars.Select(car => car.Speed).Average();
        }
    }
}
