using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRest.Controllers.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public string  LicensePlate { get; set; }
    }
}
