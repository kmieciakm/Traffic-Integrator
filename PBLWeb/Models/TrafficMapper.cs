using Integrator.Model;
using Integrator.TrafficIntensity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLWeb.Models {
    public static class TrafficMapper {
        public static TrafficIntensityVM TrafficIntensityToViewModel( TrafficIntensity trafficModel ) {
            List<CarData> cars = new List<CarData>();

            foreach (var car in trafficModel.Cars) {
                cars.Add(new CarData(
                        car.Localization,
                        car.Speed,
                        car.StartingPoint,
                        car.EndingPoint
                    ));
            }

            return new TrafficIntensityVM() {
                CarsAmount = trafficModel.GetCarsAmount(),
                Accuracy = trafficModel.Accuracy,
                SeedPoint = trafficModel.SeedPoint,
                AverageSpeed = trafficModel.GetAverageSpeed(),
                Cars = cars
            };
        }
    }
}
