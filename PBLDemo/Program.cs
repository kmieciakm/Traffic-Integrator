using Integrator;
using Integrator.Model;
using Integrator.TrafficIntensity;
using Supplier.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PBLDemo {
    class Program {
        static void Main( string[] args ) {
            string yanosikDbPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "yanosikDbGPS.json");
            Yanosik yanosik = new Yanosik(yanosikDbPath);
            List<CarData> cars = yanosik.Cars.ToList();

            Console.WriteLine("---------------------");
            Console.WriteLine("Yanosik data");
            foreach (var car in cars) {
                Console.WriteLine(car);
            }

            string aitDbPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "aitDb.json");
            AiT ait = new AiT(aitDbPath);
            List<CarData> carsAit = ait.Cars.ToList();

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("AiT data");
            foreach (var car in carsAit) {
                Console.WriteLine(car);
            }

            TrafficIntensityIntegrator integrator = new TrafficIntensityIntegrator(new List<ITrafficSupplier>() {
                new Yanosik(yanosikDbPath),
                new AiT(aitDbPath) 
            });

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Integrated data");
            foreach (var car in integrator.GetTrafficIntensity().GetCars()) {
                Console.WriteLine(car);
            }
            Console.WriteLine($"Cars amount: {integrator.GetTrafficIntensity().GetCarsAmount()}");
            Console.WriteLine($"Average speed: {integrator.GetTrafficIntensity().GetAverageSpeed()}");
            Console.WriteLine();
        }
    }
}
