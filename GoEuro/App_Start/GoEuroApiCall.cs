using GoEuroAPiClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GoEuro.App_Start
{
    public static class GoEuroApiCall
    {
        public static async Task<string> Start()
        {
            //Init
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            System.Net.ServicePointManager.DefaultConnectionLimit = 500;

            //Datum
            DateTime fromDate = new DateTime(2017, 1, 25);
            DateTime toDate = new DateTime(2017, 1, 31);

            //string departurePosition = "9177";
            //string arrivalPosition = "36067";

            string departurePosition = "377001";
            string arrivalPosition = "376422";

            //string departureDate = "";

            return await GOEuroApi_Requests.BaueFrontEndObject(departurePosition: departurePosition, arrivalPosition: arrivalPosition,/* departureDate: departureDate,*/ fromDate: fromDate, toDate: toDate);
        }

    }
}

