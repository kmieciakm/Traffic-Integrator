using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.TrafficIntensity;
using Integrator.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Supplier.Model {
    public class AiT : ITrafficSupplier {
        private string _DbPath { get; set; }

        public IEnumerable<CarData> Cars { get; private set; }

        public AiT( string path ) {
            _DbPath = path;
            LoadData();
        }

        private void LoadData() {
            Cars = JsonConvert.DeserializeObject<IEnumerable<CarData>>(
                    File.ReadAllText(_DbPath)
                );
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            return GetCarsWithAccuracy(localization, TrafficIntensityIntegrator.DefaultAccuracy);
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, int accuracy ) {
            return Cars
                .Where(
                    car => Distance.LocalizationDistance(localization, car.Localization) < accuracy)
                .ToList();
        }
    }
}
