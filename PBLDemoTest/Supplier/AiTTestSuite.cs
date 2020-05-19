using Integrator.Model;
using Integrator.Model.Localization;
using Newtonsoft.Json;
using Supplier.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace PBLDemoTest.Supplier {
    public class AiTTestSuite : IClassFixture<JsonFileFixture> {
        private JsonFileFixture _Fixture;

        public AiTTestSuite( JsonFileFixture fixture ) {
            _Fixture = fixture;
        }

        [Fact]
        public void AiT_InitTest_AsserTrue() {
            Assert.True(true);
        }

        [Fact]
        public void AiT_GetCars_AllReturned() {
            List<CarData> cars = new List<CarData> {
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
            _Fixture.SaveToFile(cars);

            AiT ait = new AiT(_Fixture.DbPath);

            Assert.Equal(cars, ait.Cars);
        }
    }

    public class JsonFileFixture : IDisposable {
        public JsonFileFixture() {
            DbPath = Path.Combine(Environment.CurrentDirectory, "tempDb.json");
            File.Create(DbPath).Close();
        }

        public void SaveToFile( Object objToSerialize ) {
            string content = JsonConvert.SerializeObject(objToSerialize);
            File.WriteAllText(DbPath, content);
        }

        public void Dispose() {
            File.Delete(DbPath);
        }

        public string DbPath { get; set; }
    }
}
