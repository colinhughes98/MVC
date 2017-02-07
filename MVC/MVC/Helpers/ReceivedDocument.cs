using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Messaging.Models;

namespace MVC.Helpers
{
    public class ReceivedDocument
    {
        public static void HandleDocument(string responseDoc, BetDocumentViewModel betDocumentViewModel)
        {
            if (!string.IsNullOrEmpty(responseDoc))
            {
                //deserialze
                var betDoc = Helpers.Serialisation.Deserialize<BetDocument>(responseDoc);
                //display
                betDocumentViewModel.Market = betDoc.Market;
                betDocumentViewModel.Odds = betDoc.BookiesOdds.ToString(CultureInfo.InvariantCulture);
                betDocumentViewModel.Title = "Little Test";
            }
        }
    }
}