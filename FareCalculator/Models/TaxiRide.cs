using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FareCalculator.Models
{
    public class TaxiRide
    {
        #region Instance Variables
        public int miles { get; set; }
        public int minutes { get; set; }
        public string state { get; set; }
        public DateTime RideTime { get; set; }
        #endregion
        #region Static Data

        // -----------------------------
        // Establish the time of each surcharge hours
        // 6:00 am = 6 h
        // 4:00 pm = 16 h
        // 8:00 pm = 20 h
        // -----------------------------
        private static decimal BeginNightHours = 20;
        private static decimal EndNightHours = 6;
        private static decimal BeginPeakHours = 16;
        private static decimal EndPeakHours = 20;
        #endregion
        #region Utility Methods

        // ----------------------------------------------------------
        // This method will check whether or not we are calculating the fare on a weekend or not.
        // This will be necessary to determine if we qualify for the Peak Hour surcharge.
        // ----------------------------------------------------------
        public bool CheckPeakWeekend(DateTime adt_ride_time)
        {
            return (adt_ride_time.DayOfWeek == DayOfWeek.Saturday || adt_ride_time.DayOfWeek == DayOfWeek.Sunday);
        }

        // ----------------------------------------------------------
        // This method will check whether or not we are within the time constraints of peak hours
        // ----------------------------------------------------------
        public bool CheckPeakNightHour(DateTime adt_ride_time)
        {
            // ----------------------------------------------------------
            // Check to see if it the day is a not on the weekend.
            // If it is a week day, then see if the time falls within the Peak Hours surcharge range.
            // ----------------------------------------------------------
            if (!CheckPeakWeekend(adt_ride_time))
            {
                return (adt_ride_time.Hour > BeginPeakHours && adt_ride_time.Hour < EndPeakHours);
            }

            // ----------------------------------------------------------
            // It is the weekend, then the peak hours surcharge does not apply.
            // ----------------------------------------------------------
            return false;
        }

        // ----------------------------------------------------------
        // Check to see if the time of the ride falls before 6:00 am or after 8:00 pm
        // This will be used to determine if this ride has a Night surcharge.
        // ----------------------------------------------------------
        public bool CheckNightHours(DateTime adt_ride_time)
        {
            return (adt_ride_time.Hour > BeginNightHours || adt_ride_time.Hour < EndNightHours);
        }

        // ----------------------------------------------------------
        // Check to see if the state is New York.
        // This method will be used to determine if the NY state tax surcharge is applicable.
        // ----------------------------------------------------------
        public bool CheckState(String as_state)
        {
            return (as_state == "New York");
        }
        #endregion
    }
}