using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrator.TrafficIntensity {
    public class TrafficIntensityIntegrator : ITrafficIntensityIntegrator {
        private IEnumerable<ITrafficSupplier> _Suppliers { get; set; }
        public static int DefaultAccuracy { get { return 100; } }

        public TrafficIntensityIntegrator( IEnumerable<ITrafficSupplier> suppliers ) {
            _Suppliers = suppliers;
        }

        public int GetSuppliersAmount() {
            return _Suppliers.Count();
        }

        public TrafficIntensity GetTrafficIntensity() {
            List<ICarData> allCars = new List<ICarData>();
            foreach (var supplier in _Suppliers) {
                allCars.AddRange(supplier.Cars);
            }
            return new TrafficIntensity(new CarLocalization(new Coordinate(0, 0)), DefaultAccuracy, allCars);
        }

        public TrafficIntensity GetTrafficIntensityAt( ILocalization localization ) {
            List<ICarData> allCars = new List<ICarData>();
            foreach (var supplier in _Suppliers) {
                allCars.AddRange(supplier.GetCarsAt(localization));
            }
            return new TrafficIntensity(localization, DefaultAccuracy, allCars);
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
