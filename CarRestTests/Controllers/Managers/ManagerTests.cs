using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRest.Controllers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRest.Controllers.Models;

namespace CarRest.Controllers.Managers.Tests
{
    [TestClass()]
    public class ManagerTests
    {
        private Manager _manager;

        [TestInitialize]
        public void SetUp()
        {
            _manager = new Manager();
        }
        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_manager.GetAll(null, null, null));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_manager.GetById(1));
            Assert.IsNull(_manager.GetById(0));

            Assert.AreEqual("Performance", _manager.GetById(1).Model);
            Assert.AreEqual(845000, _manager.GetById(1).Price);
            Assert.AreEqual("MT69690", _manager.GetById(1).LicensePlate);
        }

        [TestMethod()]
        public void PostCarTest()
        {
            var car = new Car
            {
                Model = "Hund",
                Price = 356,
                LicensePlate = "WR10295"
            };
            Car testCar = _manager.PostCar(car);
            Assert.IsNotNull(testCar);
            Assert.AreEqual(car, testCar);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Car deleteCar = _manager.Delete(3);
            Assert.IsNotNull(deleteCar);
        }
    }
}