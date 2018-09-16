using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FareCalculator.Models
{
    public class Rates
    {
        #region Rate-to-Cost Conversions
        public decimal UnitRate
        {
            get
            {
                return 0.35m;
            }
        }
        public decimal TimeRate
        {
            get
            {
                return 1.0m;
            }
        }
        public decimal DistanceRate
        {
            get
            {
                return 0.2m;
            }
        }
        #endregion
        #region Fees
        public decimal EntryFee
        {
            get
            {
                return 3.0m;
            }
        }
        public decimal NightSurcharge
        {
            get
            {
                return 0.50m;
            }
        }
        public decimal PeakSurcharge
        {
            get
            {
                return 1.0m;
            }
        }
        public decimal NYStateTax
        {
            get
            {
                return 0.5m;
            }
        }
        #endregion
    }
}