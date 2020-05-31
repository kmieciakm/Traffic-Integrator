using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using PBLWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public class GeneralSupplier : ITrafficSupplier {
        private SupplierData _SupplierData { get; set; }

        public GeneralSupplier( SupplierData supplierData ) {
            _SupplierData = supplierData;
        }

        public IEnumerable<CarData> Cars { 
            get {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            throw new NotImplementedException();
        }
    }
}
