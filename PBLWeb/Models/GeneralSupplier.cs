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
                IHttpClientFactory clientFactory ) {
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

            if (response.IsSuccessStatusCode) {
                string json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CarData>>(json);

                return data;
            }

            return new List<CarData>();
        }

        public IEnumerable<CarData> GetCarsAt( ILocalization localization ) {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_SupplierData.ApiUrl}/cars/{localization.Coordinate.Latitude}/{localization.Coordinate.Longitude}");
            var client = _ClientFactory.CreateClient();
            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode) {
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<CarData>>(json);

                return data;
            }

            return new List<CarData>();
        }

        public IEnumerable<CarData> GetCarsWithAccuracy( ILocalization localization, int accuracy ) {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_SupplierData.ApiUrl}/cars/{localization.Coordinate.Latitude}/{localization.Coordinate.Longitude}/{accuracy}");
            var client = _ClientFactory.CreateClient();
            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode) {
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<CarData>>(json);

                return data;
            }

            return new List<CarData>();
        }
    }
}
