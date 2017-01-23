using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GoEuro.App_Start;
using System.Threading;
using System.Globalization;
using GoEuroAPiClassLibrary;

namespace GoEuro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TesteBeginForm()
        {
            return View();
        }

        public ActionResult POST_TesteBeginForm(FormCollection collection)
        {
            string valueFromNameTextBox = collection["I_startort"];

            return View();
        }

        public ActionResult Index()
        {
            //App_Start.Testing.POST();
            return View();
        }

        //[HttpPost]POST_GoEuroApiCall
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<string> POST_GoEuroApiCall(FormCollection collection)
        {
            string datumsFormat = "dd.MM.yyyy";

            //Init
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            System.Net.ServicePointManager.DefaultConnectionLimit = 500;

            string departurePosition = collection["I_startort"];
            string arrivalPosition = collection["I_zielort"];

            DateTime fromDate = DateTime.Now;

            if (!String.IsNullOrEmpty(collection["I_startzeitpunkt"]))
            {
                fromDate = DateTime.ParseExact(collection["I_startzeitpunkt"], datumsFormat, CultureInfo.CurrentCulture);
            }

            DateTime toDate = DateTime.Now.AddDays(6);

            if (!String.IsNullOrEmpty(collection["I_endzeitpunkt"]))
            {
                toDate = DateTime.ParseExact(collection["I_endzeitpunkt"], datumsFormat, CultureInfo.CurrentCulture); ;
            }

            string days = collection["I_checkBox"];



            #region Testing

            ////Datum
            //DateTime fromDate = new DateTime(2017, 1, 25);
            //DateTime toDate = new DateTime(2017, 2, 10);


            //string departurePosition = "403838";// "376946";// "377001";
            //string arrivalPosition = "377001";

            ////string departureDate = ""; 
            #endregion

            //var result = "";

            var result = await GOEuroApi_Requests.BaueFrontEndObject(departurePosition: departurePosition, arrivalPosition: arrivalPosition,/* departureDate: departureDate,*/ fromDate: fromDate, toDate: toDate, day: days);

            return result;
        }

    }
}