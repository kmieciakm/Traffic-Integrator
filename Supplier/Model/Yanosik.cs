using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Model {
    public class Yanosik : ITrafficSupplier {
        public IEnumerable<ICarData> GetAllCars() {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<ICarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            throw new NotImplementedException();
        }
    }
}
