using Integrator;
using Integrator.Model;
using Integrator.TrafficIntensity;
using Supplier.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBLDemo {
    class Program {
        static void Main( string[] args ) {
            Yanosik yanosik = new Yanosik();
            List<CarData> cars = yanosik.GetAllCars().ToList();

            Console.WriteLine("---------------------");
            Console.WriteLine("Yanosik data");
            foreach (var car in cars) {
                Console.WriteLine(car);
            }

            AiT ait = new AiT();
            List<CarData> carsAit = ait.GetAllCars().ToList();

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("AiT data");
            foreach (var car in carsAit) {
                Console.WriteLine(car);
            }

            TrafficIntensityIntegrator integrator = new TrafficIntensityIntegrator(new List<ITrafficSupplier>() {
                new Yanosik(),
                new AiT() 
            });

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine("Integrated data");
            foreach (var car in integrator.GetTraffic().GetCars()) {
                Console.WriteLine(car);
            }
            Console.WriteLine($"Cars amount: {integrator.GetTraffic().GetCarsAmount()}");
            Console.WriteLine($"Average speed: {integrator.GetTraffic().GetAverageSpeed()}");
            Console.WriteLine();
        }
    }
}
