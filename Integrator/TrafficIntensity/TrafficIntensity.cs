using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrator.TrafficIntensity {
    public class TrafficIntensity : ITrafficIntensity {
        private List<ICarData> _Cars { get; set; }
        public ILocalization SeedPoint { get; }
        public int Accuracy { get; }

        public TrafficIntensity( ILocalization seedPoint, int accuracy, IEnumerable<ICarData> cars ) {
            SeedPoint = seedPoint;
            Accuracy = accuracy;
            _Cars = cars.ToList();
        }

        public int GetCarsAmount() {
            return _Cars.Count;
        }

        public IEnumerable<ICarData> GetCars() {
            return _Cars.ToList();
        }

        public double GetAverageSpeed() {
            return _Cars.Select(car => car.Speed).Average();
        }
    }
}
