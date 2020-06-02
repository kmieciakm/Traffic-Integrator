using PBLWeb.Data;
using System.Collections.Generic;

namespace PBLWeb.Areas.Identity.Repository {
    public interface ISupplierDataRepository {
        bool Add( SupplierData supplier );
        bool DeleteById( int id );
        bool Exists( int supplierId );
        SupplierData GetSupplierById( int id );
        IEnumerable<SupplierData> GetSuppliers();
        IEnumerable<SupplierData> GetActiveSuppliers();
        bool Save();
        bool Update( SupplierData supplier );
    }
}