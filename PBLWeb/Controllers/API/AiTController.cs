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

namespace PBLWeb.Controllers.API
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class AiTController : ControllerBase, ISupplierController {
        private SupplierService<AiT> _AiTService { get; }

        public AiTController( SupplierService<AiT> aiTService ) {
            _AiTService = aiTService;
        }

        [HttpGet("cars")]
        public ActionResult<IEnumerable<ICarData>> GetAllCars() {
            return new List<ICarData>(_AiTService.Cars);
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsAt( double latitude, double longitude ) {
            var cars = new List<ICarData>(
            _AiTService.GetCarsAt(
                new CarLocalization(new Coordinate(latitude, longitude))
            ));
            return cars;
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}/{accuracy:int}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsWithAccuracy( double latitude, double longitude, int accuracy ) {
            var cars = new List<ICarData>(
            _AiTService.GetCarsWithAccuracy(
                new CarLocalization(new Coordinate(latitude, longitude)),
                accuracy
            ));
            return cars;
        }
    }
}