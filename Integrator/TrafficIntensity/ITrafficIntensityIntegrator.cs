using Integrator.Model.Localization;

namespace Integrator.TrafficIntensity {
    public interface ITrafficIntensityIntegrator {
        int GetSuppliersAmount();
        TrafficIntensity GetTrafficIntensity();
        TrafficIntensity GetTrafficIntensityAt( PlaceLocalization localization );
        TrafficIntensity GetTrafficIntensityWithAccuracy( PlaceLocalization localization, int accuracy );
    }
}