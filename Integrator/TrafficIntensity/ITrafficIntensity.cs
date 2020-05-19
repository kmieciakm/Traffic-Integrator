﻿using Integrator.Model;
using Integrator.Model.Localization;
using System.Collections.Generic;

namespace Integrator.TrafficIntensity {
    public interface ITrafficIntensity {
        int Accuracy { get; }
        ILocalization SeedPoint { get; }

        float GetAverageSpeed();
        IEnumerable<ICarData> GetCars();
        int GetCarsAmount();
    }
}