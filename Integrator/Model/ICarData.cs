using Integrator.Model.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integrator.Model {
    public interface ICarData {
        CarLocalization Localization { get; set; }
        double Speed { get; set; }
        PlaceLocalization StartingPoint { get; set; }
        PlaceLocalization EndingPoint { get; set; }
    }
}
