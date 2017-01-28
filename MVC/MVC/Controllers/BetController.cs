using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class BetController : Controller
    {
        // GET: Bet
        public ActionResult Index()
        {
            string responseDoc;
            BetDocumentViewModel betDocumentViewModel = new BetDocumentViewModel();
            responseDoc = GetRequest("http://localhost/BettingAPI/api/v1/bet/1");

            HandleDocument(responseDoc, betDocumentViewModel);
            return View(betDocumentViewModel);
        }

        private static void HandleDocument(string responseDoc, BetDocumentViewModel betDocumentViewModel)
        {
            if (!string.IsNullOrEmpty(responseDoc))
            {
                //deserialze
                var betDoc = Deserialize<BetDocument>(responseDoc);
                //display
                betDocumentViewModel.Market = betDoc.Market;
                betDocumentViewModel.Odds = betDoc.BookiesOdds.ToString(CultureInfo.InvariantCulture);
                betDocumentViewModel.Title = "Little Test";
            }
        }

        private static T Deserialize<T>(string responseDoc)
        {
            var betDoc = JsonConvert.DeserializeObject<T>(responseDoc);
            return betDoc;
        }

        public static string GetRequest(string URL)
        {
            string responseDoc;
            //read URL
            var request = (HttpWebRequest) WebRequest.Create(URL);
            var response = request.GetResponse();

            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                responseDoc = stream.ReadToEnd();
            }
            return responseDoc;
        }
    }

    public class BetDocumentViewModel
    {
        public string Title { get; set; }
        public string Market { get; set; }
        public string Odds { get; set; }
    }

    public class BetDocument
    {
        public int ID { get; set; }
        public string Market { get; set; }
        public decimal BookiesOdds { get; set; }
    }
}