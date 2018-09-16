using Microsoft.VisualStudio.TestTools.UnitTesting;
using FareCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalculator.Models.Tests
{
    [TestClass()]
    public class TaxiRideTests
    {
        [TestMethod()]
        //-------------------------------
        // This tests whether or not the user is riding on a Weekend.
        // DateTime: 10/08/2010 05:00:00 pm.  This is a Friday.
        // Expected result is false.
        //-------------------------------
        public void CheckPeakWeekendTest()
        {
            TaxiRide lod_taxi_ride = new TaxiRide();
            DateTime lod_test = new DateTime();
            lod_test = DateTime.Parse("10/08/2010 05:00:00 pm");

            Assert.IsFalse(lod_taxi_ride.CheckPeakWeekend(lod_test));
        }

        [TestMethod()]
        //-------------------------------
        // This tests whether or not the user is subject to Peak Weekday surcharge.
        // DateTime: 10/08/2010 05:00:00 pm.  This is a Friday
        // Any time between 4 PM to 8 PM, Monday-Friday is subject to this surcharge.
        // Expected result is true.
        //-------------------------------
        public void CheckPeakNightHourTest()
        {
            TaxiRide lod_taxi_ride = new TaxiRide();
            DateTime lod_test = new DateTime();
            lod_test = DateTime.Parse("10/08/2010 05:00:00 pm");

            Assert.IsTrue(lod_taxi_ride.CheckPeakNightHour(lod_test));
        }

        [TestMethod()]
        //-------------------------------
        // This tests whether or not the user is subject to Night hours surcharge.
        // DateTime: 10/08/2010 11:59:00 pm.  This is a Friday
        // Any time after 8:00 PM and before 6:00 AM is subject to this charge.
        // Expected result is true.
        //-------------------------------
        public void CheckNightHoursTest()
        {
            TaxiRide lod_taxi_ride = new TaxiRide();
            DateTime lod_test = new DateTime();
            lod_test = DateTime.Parse("10/08/2010 11:59:00 pm");

            Assert.IsTrue(lod_taxi_ride.CheckNightHours(lod_test));
        }

        [TestMethod()]
        //-------------------------------
        // This tests whether or not the user is subject to New York State tax.
        // DateTime: 10/08/2010 06:00:00 pm.  This is a Friday
        // Anyone requesting a ride in New York is subject to this tax.
        // Expected result is true.
        //-------------------------------
        public void CheckStateTest()
        {
            TaxiRide lod_taxi_ride = new TaxiRide();

            Assert.IsTrue(lod_taxi_ride.CheckState("New York"));
        }
    }
}