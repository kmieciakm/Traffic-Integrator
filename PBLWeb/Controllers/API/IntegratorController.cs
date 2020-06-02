using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.TrafficIntensity;
using Microsoft.AspNetCore.Mvc;
using PBLWeb.Areas.Identity.Repository;
using PBLWeb.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PBLWeb.Controllers.API {
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class IntegratorController : Controller, ISupplierController {
        private ISupplierDataRepository _SupplierRepo { get; }
        private IHttpClientFactory _ClientFactory { get; set; }
        private TrafficIntensityIntegrator _Integrator { get; set; }

        public IntegratorController(ISupplierDataRepository supplierRepo,
                IHttpClientFactory clientFactory ) {
            _SupplierRepo = supplierRepo;
            _ClientFactory = clientFactory;
            Init();
        }

        private void Init() {
            var suppliersData = _SupplierRepo.GetActiveSuppliers();
            List<GeneralSupplier> suppliers = new List<GeneralSupplier>();

            foreach (var supplierInfo in suppliersData) {
                suppliers.Add(new GeneralSupplier(
                    supplierInfo, _ClientFactory));
            }

            _Integrator = new TrafficIntensityIntegrator(suppliers);
        }

        [HttpGet("intensity")]
        [SwaggerOperation(Summary = "Get all cars and additional analysis information")]
        public ActionResult<TrafficIntensityViewModel> GetIntensity() {
            return new TrafficIntensityViewModel(
                _Integrator.GetTrafficIntensity()
            );
        }

        [HttpGet("intensity/{latitude:double}/{longitude:double}")]
        [SwaggerOperation(Summary = "Get traffic intensity information in the region specify by latitude and longitude")]
        public ActionResult<TrafficIntensityViewModel> GetIntensityAt( double latitude, double longitude ) {
            var localization = new CarLocalization(
                new Coordinate(latitude, longitude)
            );
            return new TrafficIntensityViewModel(
                _Integrator.GetTrafficIntensityAt(localization)
            );
        }

        [HttpGet("intensity/{latitude:double}/{longitude:double}/{accuracy:int}")]
        [SwaggerOperation(Summary = "Get traffic intensity information in the region specify by latitude, longitude, and its size specify by accuracy")]
        public ActionResult<TrafficIntensityViewModel> GetIntensityWithAccuracy( double latitude, double longitude, int accuracy ) {
            var localization = new CarLocalization(
                new Coordinate(latitude, longitude)
            );
            return new TrafficIntensityViewModel(
                _Integrator.GetTrafficIntensityWithAccuracy(localization, accuracy)
            );
        }

        [HttpGet("cars")]
        [SwaggerOperation(Summary = "Get all cars")]
        public ActionResult<IEnumerable<ICarData>> GetAllCars() {
            return new List<ICarData>(
                _Integrator.GetTrafficIntensity().GetCars()
            );
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}")]
        [SwaggerOperation(Summary = "Get cars from the region specify by latitude and longitude")]
        public ActionResult<IEnumerable<ICarData>> GetCarsAt( double latitude, double longitude ) {
            var localization = new CarLocalization(
                new Coordinate(latitude, longitude)
            );
            return new List<ICarData>(
                _Integrator.GetTrafficIntensityAt(localization).GetCars()
            );
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}/{accuracy:int}")]
        [SwaggerOperation(Summary = "Get cars from the region specify by latitude, longitude, and its size specify by accuracy")]
        public ActionResult<IEnumerable<ICarData>> GetCarsWithAccuracy( double latitude, double longitude, int accuracy ) {
            var localization = new CarLocalization(
                new Coordinate(latitude, longitude)
            );
            return new List<ICarData>(
                _Integrator.GetTrafficIntensityWithAccuracy(localization, accuracy).GetCars()
            );
        }
    }
}
