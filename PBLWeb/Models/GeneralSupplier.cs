using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Newtonsoft.Json;
using PBLWeb.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public class GeneralSupplier : ITrafficSupplier {
        private SupplierData _SupplierData { get; set; }
        private IHttpClientFactory _ClientFactory { get; set; }

        public GeneralSupplier( SupplierData supplierData,
                IHttpClientFactory clientFactory) {
            _SupplierData = supplierData;
            _ClientFactory = clientFactory;
        }

        public IEnumerable<CarData> Cars {
            get {
                return GetCarsAsync().Result;
            }
        }

        private async Task<IEnumerable<CarData>> GetCarsAsync() {
            var request = new HttpRequestMessage(HttpMethod.Get, _SupplierData.ApiUrl + "/cars");
            var client = _ClientFactory.CreateClient();
            var response = client.SendAsync(request).Result;

            string json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CarData>>(json);

            return data;
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            throw new NotImplementedException();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, float accuracy ) {
            throw new NotImplementedException();
        }
    }
}
