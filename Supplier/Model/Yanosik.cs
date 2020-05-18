using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Supplier.Model {
    public class Yanosik : ITrafficSupplier {
        private string _DbPath {
            get {
                return Path.Combine(Environment.CurrentDirectory, @"Data\", "yanosikDb.json");
            }
        }

        public Yanosik() {
            if (!File.Exists(_DbPath)) {
                SeedData();
            }
            LoadData();
        }

        private IEnumerable<CarData> _Cars { get; set; }

        private void LoadData() {
            _Cars = JsonConvert.DeserializeObject<IEnumerable<CarData>>(
                    File.ReadAllText(_DbPath)
                );
        }

        private void SeedData() {
            _Cars = new List<CarData> {
                new CarData(
                    new CarLocalization(new Coordinate(34.43422M, 45.12312M)),
                    21.92f),
                new CarData(
                    new CarLocalization(new Coordinate(-34.75431M, 89.34210M)),
                    30.56f),
                new CarData(
                    new CarLocalization(new Coordinate(21.34391M, 32.12902M)),
                    26.34f)
            };
            var obj = JsonConvert.SerializeObject(_Cars);
            if (!File.Exists(_DbPath)) {
                using (var stream = File.Create(_DbPath)) {}
            }
            File.WriteAllText(_DbPath, obj);
        }

        public IEnumerable<CarData> GetAllCars() {
            return _Cars.ToList();
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            throw new NotImplementedException();
        }
    }
}
