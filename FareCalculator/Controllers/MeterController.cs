using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FareCalculator.Models;

namespace FareCalculator.Controllers
{
    public class MeterController : ApiController
    {
        private RateCalculator lod_rate_calc = new RateCalculator();
        
        [HttpPost]
        public HttpResponseMessage Calculate(TaxiRide aod_taxi_ride)
        {
            var cost = lod_rate_calc.CalcRate(aod_taxi_ride);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new { cost = cost });
            return response;
        }
    }
}
