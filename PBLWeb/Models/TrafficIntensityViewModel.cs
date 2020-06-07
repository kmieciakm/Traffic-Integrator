using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.TrafficIntensity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public class TrafficIntensityViewModel {
        private ITrafficIntensity _TrafficIntensity { get; set; }

        public TrafficIntensityViewModel( ITrafficIntensity trafficIntensity ) {
            _TrafficIntensity = trafficIntensity;
        }

        public IEnumerable<ICarData> Cars { get { return _TrafficIntensity.GetCars(); } }
        public PlaceLocalization SeedPoint { get { return _TrafficIntensity.SeedPoint; } }
        public int Accuracy { get { return _TrafficIntensity.Accuracy; } }
        [Display(Name = "Cars Amount")]
        public int CarsAmount { get { return _TrafficIntensity.GetCarsAmount(); } }
        [Display(Name = "Average Speed")]
        public double AverageSpeed { get { return _TrafficIntensity.GetAverageSpeed(); } }

    }

    public class TrafficIntensityCreateViewModel {
        public List<CarData> Cars { get; set;  }
        public PlaceLocalization SeedPoint { get; set; }
        public int Accuracy { get; set; }
    }

}
