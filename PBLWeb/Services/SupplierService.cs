using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Services {
    public class SupplierService<T> where T : ITrafficSupplier {
        private T _Supplier { get; }

        public SupplierService( T supplier ) {
            _Supplier = supplier;
        }

        public IEnumerable<CarData> Cars => _Supplier.Cars;

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            return _Supplier.GetCarsAt(localization);
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, int accuracy ) {
            return _Supplier.GetCarsWithAccuracy(localization, accuracy);
        }
    }
}
