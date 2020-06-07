using Integrator.TrafficIntensity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public static class TrafficMapper {
        public static TrafficIntensity TrafficCreateModelToTrafficIntensity(
                TrafficIntensityCreateViewModel model) {
            return new TrafficIntensity(
                model.SeedPoint,
                model.Accuracy,
                model.Cars
            );
        }
    }
}
