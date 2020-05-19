using Integrator;
using Integrator.Model;
using Integrator.Model.Localization;
using Integrator.TrafficIntensity;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace PBLDemoTest.Integrator {
    public class TrafficIntensityIntegratorTestSuite {
        [Fact]
        public void TrafficIntegrator_InitTest_AsserTrue() {
            Assert.True(true);
        }

        [Fact]
        public void TrafficIntegrator_GetSuppliersAmount_Correct() {
            TrafficIntensityIntegrator integrator = new TrafficIntensityIntegrator(
                    new List<ITrafficSupplier>() {
                        new Mock<ITrafficSupplier>().Object,
                        new Mock<ITrafficSupplier>().Object,
                    }
                );
            Assert.Equal(2, integrator.GetSuppliersAmount());
        }

        [Fact]
        public void TrafficIntegrator_GetTraffic_AllCarsReturned() {
            List<CarData> carsSetOne = new List<CarData> {
                new CarData(
                    new CarLocalization(new Coordinate(34.43422, 45.12312)),
                    21.92f),
                new CarData(
                    new CarLocalization(new Coordinate(-34.75431, 89.34210)),
                    30.56f),
                new CarData(
                    new CarLocalization(new Coordinate(21.34391, 32.12902)),
                    26.34f)
            };
            List<CarData> carsSetTwo = new List<CarData> {
                new CarData(
                    new CarLocalization(new Coordinate(24.43422, 25.12312)),
                    21.92f),
                new CarData(
                    new CarLocalization(new Coordinate(-24.75431, 29.34210)),
                    30.56f),
                new CarData(
                    new CarLocalization(new Coordinate(21.34391, 22.12902)),
                    26.34f)
            };
            List<CarData> expectedCarsSet = new List<CarData>();
            expectedCarsSet.AddRange(carsSetOne);
            expectedCarsSet.AddRange(carsSetTwo);

            Mock<ITrafficSupplier> mockSupplierOne = new Mock<ITrafficSupplier>();
            mockSupplierOne.SetupGet(m => m.Cars).Returns(carsSetOne);
            Mock<ITrafficSupplier> mockSupplierTwo = new Mock<ITrafficSupplier>();
            mockSupplierTwo.SetupGet(m => m.Cars).Returns(carsSetTwo);

            TrafficIntensityIntegrator integrator = new TrafficIntensityIntegrator(
                    new List<ITrafficSupplier>() {
                        mockSupplierOne.Object,
                        mockSupplierTwo.Object
                    }
                );
            Assert.Equal(expectedCarsSet, integrator.GetTraffic().GetCars());
        }
    }

}
