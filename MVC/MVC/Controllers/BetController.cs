using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Messaging.Models;
using MVC.Helpers;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class BetController : Controller
    {
        // GET: Bet
        [HttpGet]
        public ActionResult Index()
        {
            string responseDoc;
            BetDocumentViewModel betDocumentViewModel = new BetDocumentViewModel();
            responseDoc = Messaging.MessageHandler.Message.GetRequest("http://localhost/BettingAPI/api/v1/bet/1");

            ReceivedDocument.HandleDocument(responseDoc, betDocumentViewModel);
            return View(betDocumentViewModel);
        }

        [HttpPost]
        public ActionResult Index(BetDocumentViewModel vm)
        {
            return View();
        }
    }
}