using Integrator.Model;
using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator {
    public interface ITrafficSupplier {
        IEnumerable<CarData> Cars { get; }
        IEnumerable<CarData> GetCarsAt(ILocalization localization);
        IEnumerable<CarData> GetCarsWithAccuracy(ILocalization localization, float accuracy);
    }
}
