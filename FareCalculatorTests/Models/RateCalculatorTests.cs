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
    public class RateCalculatorTests
    {
        //-----------------------------------
        // This method will test the base case.
        // The initial requirement of this project was to test these scenarios:
        // State is NY, miles traveled under 6 mph = 2, minutes traveled going above 6 mph = 5, 
        // Date: 10/08/2010
        // Time: 05:30 PM
        // Expected return value should be 9.75
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestBaseCase()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New York",
                miles = 2,
                minutes = 5,
                RideTime = DateTime.Parse("10/08/2010 05:30:00 pm")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)9.75, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }

        //-----------------------------------
        // This method will test the scenario where there are no miles traveled under 6 mph
        // State is NY, miles traveled under 6 mph = 0, minutes traveled going above 6 mph = 5, 
        // Date: 10/08/2010
        // Time: 09:30 AM
        // Expected return value should be 9.75
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestNoMiles()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New York",
                miles = 0,
                minutes = 5,
                RideTime = DateTime.Parse("10/08/2010 09:30:00 am")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)5.25, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }

        //-----------------------------------
        // This method will test the scenario where there are no minutes traveled over 6 mph
        // State is NY, miles traveled under 6 mph = 2, minutes traveled going above 6 mph = 0, 
        // Date: 10/08/2010
        // Time: 09:30 AM
        // Expected return value should be 7.00
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestNoMinutes()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New York",
                miles = 2,
                minutes = 0,
                RideTime = DateTime.Parse("10/08/2010 09:30:00 am")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)7, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }

        //-----------------------------------
        // This method will test the scenario where the Night Hours surcharge applies
        // State is NY, miles traveled under 6 mph = 5, minutes traveled going above 6 mph = 5, 
        // Date: 10/08/2010
        // Time: 12:30 AM
        // Expected return value should be 14.5
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestNightHours()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New York",
                miles = 5,
                minutes = 5,
                RideTime = DateTime.Parse("10/08/2010 12:30:00 am")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)14.5, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }

        //-----------------------------------
        // This method will test the scenario where the Peak Hours surcharge applies
        // State is NY, miles traveled under 6 mph = 1, minutes traveled going above 6 mph = 5, 
        // Date: 10/08/2010
        // Time: 06:00 PM
        // Expected return value should be 8
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestPeakHours()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New York",
                miles = 1,
                minutes = 5,
                RideTime = DateTime.Parse("10/08/2010 06:00:00 PM")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)8, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }

        //-----------------------------------
        // This method will test the scenario where the NY state tax does not apply
        // State is NY, miles traveled under 6 mph = 1, minutes traveled going above 6 mph = 5, 
        // Date: 10/08/2010
        // Time: 09:08:00 AM
        // Expected return value should be 8.25
        //-----------------------------------
        [TestMethod()]
        public void CalcRateTestNoNYTax()
        {
            TaxiRide lod_taxi_ride = new TaxiRide()
            {
                state = "New Jersey",
                miles = 2,
                minutes = 5,
                RideTime = DateTime.Parse("10/08/2010 09:08:00 AM")
            };
            RateCalculator lod_rate_calculator = new RateCalculator();

            Assert.AreEqual((decimal)8.25, lod_rate_calculator.CalcRate(lod_taxi_ride));
        }
    }
}