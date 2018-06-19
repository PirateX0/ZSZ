using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service;

namespace ServiceTests
{
    [TestClass]
    public class CityUnitTest
    {
        [TestMethod]
        public void Test1()
        {
            string cityName = DateTime.Now.ToFileTimeUtc().ToString();
            CityService citySvc = new CityService();
            long cityId = citySvc.AddNew(cityName);
            Assert.AreEqual(citySvc.GetById(cityId).Name, cityName);
            citySvc.GetAll();
            
        }

        [TestMethod]
        public void Test2()
        {
            CityService cityService = new CityService();
            string cityName = DateTime.Now.ToFileTimeUtc().ToString();
            long cityId = cityService.AddNew(cityName);

            RegionService regionSvc = new RegionService();
            string regionName = DateTime.Now.ToFileTimeUtc().ToString();
            long regionId= regionSvc.Add(regionName,cityId);
            var region = regionSvc.GetById(regionId);
            Assert.AreEqual(region.CityName, cityName);
            Assert.AreEqual(region.Name,regionName);
            Assert.AreEqual(regionSvc.GetAll(cityId).Length, 1);
        }
    }
}
