using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model {
    public interface ICarData {
        CarLocalization Localization { get; set; }
        float Speed { get; set; }
    }
}
