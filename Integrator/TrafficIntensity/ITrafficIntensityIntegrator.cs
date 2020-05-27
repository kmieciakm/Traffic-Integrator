using Integrator.Model.Localization;

namespace Integrator.TrafficIntensity {
    public interface ITrafficIntensityIntegrator {
        int GetSuppliersAmount();
        TrafficIntensity GetTrafficIntensity();
        TrafficIntensity GetTrafficIntensityAt( ILocalization localization );
        TrafficIntensity GetTrafficIntensityWithAccuracy( ILocalization localization, int accuracy );
    }
}