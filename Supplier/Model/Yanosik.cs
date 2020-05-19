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
        private string _DbPath { get; set; }

        public IEnumerable<CarData> Cars { get; private set; }

        public Yanosik(string path) {
            _DbPath = path;
            if (!File.Exists(_DbPath)) {
                SeedData();
            }
            LoadData();
        }

        private void LoadData() {
            Cars = JsonConvert.DeserializeObject<IEnumerable<CarData>>(
                    File.ReadAllText(_DbPath)
                );
        }

        private void SeedData() {
            Cars = new List<CarData> {
                new CarData(
                    new CarLocalization(new Coordinate(34.43422, 45.12312)),
                    21.92f),
                new CarData(
                    new CarLocalization(new Coordinate(-34.75431, 89.34210)),
                    30.56f),
                new CarData(
                    new CarLocalization(new Coordinate(21.34391, 32.12902)),
                    26.34f)
            };
            var obj = JsonConvert.SerializeObject(Cars);
            if (!File.Exists(_DbPath)) {
                using (var stream = File.Create(_DbPath)) {}
            }
            File.WriteAllText(_DbPath, obj);
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            throw new NotImplementedException();
        }
    }
}
