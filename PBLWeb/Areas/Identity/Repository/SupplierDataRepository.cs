using PBLWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Areas.Identity.Repository {
    public class SupplierDataRepository {
        private AppDBContext _Context { get; }

        public SupplierDataRepository( AppDBContext context ) {
            _Context = context;
        }

        public IEnumerable<SupplierData> GetSuppliers() {
            return _Context.Suppliers.ToList();
        }

        public SupplierData GetSupplierById(int id) {
            return _Context.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public bool Add( SupplierData supplier ) {
            _Context.Add(supplier);
            return Save();
        }

        public bool Update( SupplierData supplier ) {
            _Context.Suppliers.Update(supplier);
            return Save();
        }

        public bool DeleteById( int id ) {
            var supplier = GetSupplierById(id);
            _Context.Suppliers.Remove(supplier);
            return Save();
        }

        public bool Exists( int supplierId ) {
            return GetSupplierById(supplierId) != null;
        }

        public bool Save() {
            return _Context.SaveChanges() > 0;
        }

    }
}
