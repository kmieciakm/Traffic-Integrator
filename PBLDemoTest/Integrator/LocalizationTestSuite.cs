using Integrator.Model.Localization;
using Integrator.Utility;
using System;
using Xunit;

namespace PBLDemoTest.Integrator {
    public class LocalizationTestSuite {
        [Fact]
        public void LocalizationTestSuite_InitTest_AsserTrue() {
            Assert.True(true);
        }

        [Fact]
        public void Localization_GetDistance_Correct() {
            CarLocalization locOne = new CarLocalization(
                    new Coordinate(19.45509, 51.77469)
                );
            CarLocalization locTwo = new CarLocalization(
                    new Coordinate(19.45556, 51.77263)
                );
            double expectedDistance = 222.22;
            double errorBound = 1;
            Assert.InRange(
                Distance.LocalizationDistance(locOne, locTwo),
                expectedDistance - errorBound,
                expectedDistance + errorBound);
        }

        [Fact]
        public void Localization_GetBigDistance_Correct() {
            CarLocalization locOne = new CarLocalization(
                    new Coordinate(51.77828, 19.45139)
                );
            CarLocalization locTwo = new CarLocalization(
                    new Coordinate(51.75884, 19.45569)
                );
            double expectedDistance = 2181.79;
            double errorBound = 3;
            Assert.InRange(
                Distance.LocalizationDistance(locOne, locTwo),
                expectedDistance - errorBound,
                expectedDistance + errorBound);
        }

    }
}
