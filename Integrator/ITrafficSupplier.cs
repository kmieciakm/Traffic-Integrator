using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator {
    public interface ITrafficSupplier {
        IEnumerable<ICarData> GetAllCars();
        IEnumerable<ICarData> GetCarsAt(ILocalization localization);
        IEnumerable<ICarData> GetCarsWithAccuracy(ILocalization localization, float accuracy);
    }
}
