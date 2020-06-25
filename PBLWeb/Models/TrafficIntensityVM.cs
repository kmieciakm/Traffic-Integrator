using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.TrafficIntensity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public class TrafficIntensityVM {
        public List<CarData> Cars { get; set;  }
        public PlaceLocalization SeedPoint { get; set; }
        public int Accuracy { get; set; }
        [Display(Name = "Cars amount")]
        public int CarsAmount { get; set; }
        [Display(Name = "Average Speed")]
        public double AverageSpeed { get; set; }
    }

}
