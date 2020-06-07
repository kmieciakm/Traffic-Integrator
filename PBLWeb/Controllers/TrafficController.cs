using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Integrator.TrafficIntensity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PBLWeb.Controllers.API;
using PBLWeb.Models;

namespace PBLWeb.Controllers {
    public class TrafficController : Controller {
        private readonly ILogger<TrafficController> _logger;
        private IHttpClientFactory _ClientFactory { get; set; }

        public TrafficController( ILogger<TrafficController> logger,
                IHttpClientFactory clientFactory ) {
            _logger = logger;
            _ClientFactory = clientFactory;
        }

        // GET: Traffic
        public ActionResult Index() {
            return View(null);
        }

        // POST
        public ActionResult SearchTraffic(TrafficSearchViewModel searchModel) {
            _logger.LogInformation("Searched traffic at {lat}, {long} with accuracy {acc}",
                searchModel.Latitude, searchModel.Longitude, searchModel.Accuracy);

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44313/api/1.0/integrator/intensity/{searchModel.Latitude}/{searchModel.Longitude}/{searchModel.Accuracy}");
            var client = _ClientFactory.CreateClient();
            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode) {
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<TrafficIntensityCreateViewModel>(json);
                var traffic = TrafficMapper.TrafficCreateModelToTrafficIntensity(data);
                return View("Index", new TrafficIntensityViewModel(traffic));
            }

            return View("Index", null);
        }
    }
}