using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;

namespace Supplier.Model {
    public class TomTom : ITrafficSupplier {
        public IEnumerable<CarData> Cars => throw new NotImplementedException();

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, int accuracy ) {
            throw new NotImplementedException();
        }
    }
}
