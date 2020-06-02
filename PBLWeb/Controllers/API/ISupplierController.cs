using Integrator.Model;
using Integrator.Model.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Controllers.API {
    interface ISupplierController {
        ActionResult<IEnumerable<ICarData>> GetAllCars();
        ActionResult<IEnumerable<ICarData>> GetCarsAt( double latitude, double longitude );
        ActionResult<IEnumerable<ICarData>> GetCarsWithAccuracy( double latitude, double longitude, int accuracy );
    }
}
