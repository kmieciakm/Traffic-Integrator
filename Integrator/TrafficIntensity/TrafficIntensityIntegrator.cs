using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.TrafficIntensity {
    public class TrafficIntensityIntegrator {
        private IEnumerable<ITrafficSupplier> _Suppliers { get; set; }

        public TrafficIntensityIntegrator( IEnumerable<ITrafficSupplier> suppliers ) {
            _Suppliers = suppliers;
        }

        public TrafficIntensity GetTraffic() {
            List<ICarData> allCars = new List<ICarData>();
            foreach (var supplier in _Suppliers) {
                allCars.AddRange(supplier.GetAllCars());
            }
            return new TrafficIntensity(new CarLocalization(new Coordinate(0,0)), allCars);
        }

        public TrafficIntensity GetTrafficIntensityAt( ILocalization localization ) {
            List<ICarData> allCars = new List<ICarData>();
            foreach (var supplier in _Suppliers) {
                allCars.AddRange(supplier.GetCarsAt(localization));
            }
            return new TrafficIntensity(localization, allCars);
        }

        public TrafficIntensity GetTrafficIntensityWithAccuracy( ILocalization localization, int accuracy ) {
            List<ICarData> allCars = new List<ICarData>();
            foreach (var supplier in _Suppliers) {
                allCars.AddRange(supplier.GetCarsAt(localization));
            }
            return new TrafficIntensity(localization, accuracy, allCars);
        }
    }
}
