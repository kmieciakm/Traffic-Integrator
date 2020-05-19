using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.Model.Localization.Utility;
using Integrator.TrafficIntensity;
using Integrator.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Supplier.Model {
    public class Yanosik : ITrafficSupplier {
        private string _DbPath { get; set; }

        public IEnumerable<CarData> Cars { get; private set; }

        public Yanosik( string path ) {
            _DbPath = path;
            LoadData();
        }

        private void LoadData() {
            var yanosikCars = JsonConvert.DeserializeObject<IEnumerable<YanosikCar>>(
                    File.ReadAllText(_DbPath)
                );
            List<CarData> cars = new List<CarData>();
            foreach (var car in yanosikCars) {
                cars.Add(CarMapper.YanosikCarToCarData(car));
            }
            Cars = cars;
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            return GetCarsWithAccuracy(localization, TrafficIntensityIntegrator.DefaultAccuracy);
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            return Cars
                .Where(
                    car => Distance.LocalizationDistance(localization, car.Localization) < accuracy)
                .ToList();
        }
    }

    public class YanosikCar {
        public GPSCoordinates GPSCoordinates { get; set; }
        public double Speed { get; set; }

        public YanosikCar( GPSCoordinates gPSCoordinates, double speed ) {
            GPSCoordinates = gPSCoordinates;
            Speed = speed;
        }
    }

    public static class CarMapper {
        public static CarData YanosikCarToCarData( YanosikCar yanosikCar ) {
            return new CarData(
                    new CarLocalization(Coordinates.GPSToLatLong(yanosikCar.GPSCoordinates)),
                    yanosikCar.Speed
                );
        }
    }
}
