using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.Model.Localization.Utility;
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

        [Fact]
        public void Localization_ConvertCoordinates_CorrectCoordinates() {
            GPSCoordinates gps = new GPSCoordinates(
                    new GPSLocalization(46, 58, 41.0376, Compass.North),
                    new GPSLocalization(23, 18, 12.582, Compass.East)
                );
            Coordinate coordinate = Coordinates.GPSToLatLong(gps);
            Coordinate expectedCoordinate = new Coordinate(46.978066, 23.303495);
            double errorBound = 0.00001;

            Assert.InRange(coordinate.Latitude,
                    expectedCoordinate.Latitude - errorBound,
                    expectedCoordinate.Latitude + errorBound
                );

            Assert.InRange(coordinate.Longitude,
                    expectedCoordinate.Longitude - errorBound,
                    expectedCoordinate.Longitude + errorBound
                );
        }

        [Fact]
        public void Localization_ConvertCoordinates_2_CorrectCoordinates() {
            GPSCoordinates gps = new GPSCoordinates(
                    new GPSLocalization(34, 33, 36.72, Compass.South),
                    new GPSLocalization(58, 24, 50.7888, Compass.West)
                );
            Coordinate coordinate = Coordinates.GPSToLatLong(gps);
            Coordinate expectedCoordinate = new Coordinate(-34.560200, -58.414108);
            double errorBound = 0.00001;

            Assert.InRange(coordinate.Latitude,
                    expectedCoordinate.Latitude - errorBound,
                    expectedCoordinate.Latitude + errorBound
                );

            Assert.InRange(coordinate.Longitude,
                    expectedCoordinate.Longitude - errorBound,
                    expectedCoordinate.Longitude + errorBound
                );
        }

    }
}
