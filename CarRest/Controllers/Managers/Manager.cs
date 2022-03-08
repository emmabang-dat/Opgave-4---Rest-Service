using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRest.Controllers.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace CarRest.Controllers.Managers
{
    public class Manager
    {
        private static int nextId = 1;
        private static List<Car> carData = new List<Car>()
        {
            new Car() {Id = nextId++, Model = "Performance", Price = 845000, LicensePlate = "MT69690"},
            new Car() {Id = nextId++, Model = "Model 3", Price = 650000, LicensePlate = "AF12345"},
            new Car() {Id = nextId++, Model = "Model X", Price = 900000, LicensePlate = "EB56789"},
            new Car() {Id = nextId++, Model = "Model S", Price = 56000, LicensePlate = "KO90900"},
            new Car() {Id = nextId++, Model = "Model Y", Price = 780000, LicensePlate = "SO13579"},
        };

        public List<Car> GetAll(string? modelFilter, int? priceFilter, string? licensePlateFilter)
        {
            List<Car> result = new List<Car>(carData);
            if (!string.IsNullOrWhiteSpace(modelFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter != null)
            {
                result = result.FindAll(filterCar => filterCar.Price <= priceFilter);
            }

            if (!string.IsNullOrWhiteSpace(licensePlateFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.LicensePlate.Contains(licensePlateFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Car GetById(int id)
        {
            return carData.Find(car => car.Id == id);
        }

        public Car PostCar (Car newCar)
        {
            newCar.Id = nextId++;
            carData.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = carData.Find(car => car.Id == id);
            if (car == null) return null;
            carData.Remove(car);
            return car;
        }

    }
}
