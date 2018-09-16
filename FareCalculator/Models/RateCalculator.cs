using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FareCalculator.Models
{
    public class RateCalculator
    {
        private Rates lr_rates = new Rates();
        public decimal CalcRate(TaxiRide aod_taxi_ride)
            {
            //---------------------------------------------------------
            // Declare any instance variables required for this method
            //---------------------------------------------------------
            DateTime ldt_ride_time = aod_taxi_ride.RideTime;
            decimal ld_total = 0;
            decimal ld_milesUnits = 0;
            decimal ld_minutesUnits = 0;
            String ls_state = aod_taxi_ride.state;

            //---------------------------------------------------------
            // First, add the entry fee
            //---------------------------------------------------------
            ld_total += lr_rates.EntryFee;

            //---------------------------------------------------------
            // Calculate the unit value of travel for distance traveled while driving
            // less than 6 mph
            //---------------------------------------------------------
            ld_milesUnits = (aod_taxi_ride.miles / lr_rates.DistanceRate);

            //---------------------------------------------------------
            // Calculate the unit value of travel when speed is faster than 6 mph
            //---------------------------------------------------------
            ld_minutesUnits = (aod_taxi_ride.minutes / lr_rates.TimeRate);

            //---------------------------------------------------------
            // Calculate the ld_total unit cost for both distance and time
            //---------------------------------------------------------
            ld_total += (ld_milesUnits + ld_minutesUnits) * lr_rates.UnitRate;

            //---------------------------------------------------------
            // Determine the state to see if we have to calculate additional state fares
            //---------------------------------------------------------
            if (aod_taxi_ride.CheckState(ls_state))
            {
                //---------------------------------------------------------
                // Add an additional $0.50 surcharge for New York State Tax
                //---------------------------------------------------------
                ld_total += lr_rates.NYStateTax;
            }

            //---------------------------------------------------------
            // Determine if there are Peak hour costs
            //---------------------------------------------------------
            if (aod_taxi_ride.CheckPeakNightHour(ldt_ride_time))
            {
                ld_total += lr_rates.PeakSurcharge;
            }

            //---------------------------------------------------------
            // Determine if there is a Night surcharge
            //---------------------------------------------------------
            if (aod_taxi_ride.CheckNightHours(ldt_ride_time))
            {
                ld_total += lr_rates.NightSurcharge;
            }

            //---------------------------------------------------------
            // Return the calculated cost
            //---------------------------------------------------------
            return ld_total;
        }
    }
}