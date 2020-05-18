using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supplier.Model {
    public class AiT : ITrafficSupplier {
        private IEnumerable<CarData> _Cars {
            get {
                return new List<CarData> {
                    new CarData(
                        new CarLocalization(new Coordinate(51.75296M, 19.46319M)),
                        2.34f),
                    new CarData(
                        new CarLocalization(new Coordinate(51.75147M, 19.46422M)),
                        3.56f),
                    new CarData(
                        new CarLocalization(new Coordinate(51.75291M, 19.46412M)),
                        2.12f)
                };
            }
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
