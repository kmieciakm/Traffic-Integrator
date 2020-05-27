using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integrator.Model;
using Integrator.Model.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBLWeb.Services;
using Supplier.Model;

namespace PBLWeb.Controllers.API {
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class YanosikController : ControllerBase, ISupplierController {
        private SupplierService<Yanosik> _YanosikService { get; set; }

        public YanosikController( SupplierService<Yanosik> yanosikService ) {
            _YanosikService = yanosikService;
        }

        [HttpGet("cars")]
        public ActionResult<IEnumerable<ICarData>> GetAllCars() {
            return new List<ICarData>(_YanosikService.Cars);
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsAt( double latitude, double longitude ) {
            var cars = new List<ICarData>(
                _YanosikService.GetCarsAt(
                    new CarLocalization(new Coordinate(latitude, longitude))
                ));
            return cars;
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}/{accuracy:int}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsWithAccuracy( double latitude, double longitude, int accuracy ) {
            var cars = new List<ICarData>(
                _YanosikService.GetCarsWithAccuracy(
                    new CarLocalization(new Coordinate(latitude, longitude)),
                    accuracy
                ));
            return cars;
        }
    }
}