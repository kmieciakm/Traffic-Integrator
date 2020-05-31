using PBLWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Areas.Identity.Repository {
    public class SupplierDataRepository {
        private DBContext _Context { get; }

        public SupplierDataRepository( DBContext context ) {
            _Context = context;
        }

        public IEnumerable<SupplierData> GetSuppliers() {
            return _Context.Suppliers.ToList();
        }

    }
}
