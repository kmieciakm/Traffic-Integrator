using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Integrator.Model;
using Integrator.TrafficIntensity;
using Microsoft.AspNetCore.Mvc;
using PBLWeb.Areas.Identity.Repository;
using PBLWeb.Models;

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
        public ActionResult<TrafficIntensityViewModel> GetIntensity() {
            return new TrafficIntensityViewModel(
                _Integrator.GetTrafficIntensity()
            );
        }

        [HttpGet("cars")]
        public ActionResult<IEnumerable<ICarData>> GetAllCars() {
            return new List<ICarData>(
                _Integrator.GetTrafficIntensity().GetCars()
            );
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsAt( double latitude, double longitude ) {
            throw new NotImplementedException();
        }

        [HttpGet("cars/{latitude:double}/{longitude:double}/{accuracy:int}")]
        public ActionResult<IEnumerable<ICarData>> GetCarsWithAccuracy( double latitude, double longitude, int accuracy ) {
            throw new NotImplementedException();
        }
    }
}
