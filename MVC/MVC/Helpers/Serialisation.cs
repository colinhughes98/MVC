using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MVC.Helpers
{
    public class Serialisation
    {
        public static T Deserialize<T>(string responseDoc)
        {
            var betDoc = JsonConvert.DeserializeObject<T>(responseDoc);
            return betDoc;
        }
    }
}