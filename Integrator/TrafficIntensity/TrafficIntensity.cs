using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrator.TrafficIntensity {
    public class TrafficIntensity {
        private List<ICarData> _Cars { get; set; }
        private int _DefaultAccuracy { get { return 100; } }

        public ILocalization SeedPoint { get; }
        public int Accuracy { get; }

        public TrafficIntensity( ILocalization seedPoint, int accuracy, IEnumerable<ICarData> cars ) {
            SeedPoint = seedPoint;
            Accuracy = accuracy;
            _Cars = cars.ToList();
        }

        public TrafficIntensity( ILocalization seedPoint, IEnumerable<ICarData> cars ) {
            SeedPoint = seedPoint;
            Accuracy = _DefaultAccuracy;
            _Cars = cars.ToList();
        }

        public int GetCarsAmount() {
            return _Cars.Count;
        }

        public IEnumerable<ICarData> GetCars() {
            return _Cars.ToList();
        }

        public float GetAverageSpeed() {
            return _Cars.Select(car => car.Speed).Average();
        }
    }
}
