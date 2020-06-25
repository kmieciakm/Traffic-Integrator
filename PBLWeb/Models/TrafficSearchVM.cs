using Integrator.TrafficIntensity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public class TrafficSearchVM {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Accuracy { get; set; } = TrafficIntensityIntegrator.DefaultAccuracy;
    }
}
