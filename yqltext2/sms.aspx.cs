using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace yqltext2
{

    public partial class sms : System.Web.UI.Page
   {
        private object httpClient;
        private string stockticker2;

        protected void Page_Load(object sender, EventArgs e)
        //public void ProcessRequest(HttpContext context)
        {




            string stockticker = "Hey there";

            stockticker = HttpContext.Current.Request.QueryString["Body"];
            if (string.IsNullOrEmpty(stockticker) == true)
            {
                stockticker = "Pizza 91011";
            }
            string[] st = stockticker.Split(' ');
            string zip = "temp";
            int stringLegnth = st.Length;
            if (stringLegnth > 1)
            {
                zip = st[1];
            }
            string item = st[0];
            



            string localsearchurl = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20local.search%20where%20zip%3D%27" + zip + "%27%20and%20query%3D%27" + item + "%27&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";


            Uri urlCheck = new Uri(localsearchurl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 15000;
            HttpWebResponse response;
            bool result = true;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                result = false;
            }
            string results = "";
            if (result == true)
            {
                using (WebClient wc = new WebClient())

                {


                    results = wc.DownloadString(localsearchurl.ToString());
                }


                JObject dataObject = JObject.Parse(results);
                object arraynull = (object)dataObject["query"]["results"];
                string arrayTwoNull = Convert.ToString(arraynull);
                string jsonthreearray = "";
                if (string.IsNullOrWhiteSpace(arrayTwoNull))
                {
                    jsonthreearray = "Not valid location/zip";
                }

            else
            {
                string jsonarray = (string)dataObject["query"]["results"]["Result"][0]["Title"];
                string jsontwoarray = (string)dataObject["query"]["results"]["Result"][0]["Address"];
                jsonthreearray = jsonarray + " " + jsontwoarray;
            }


                Response.ContentType = "text/xml";
                var twiml = new Twilio.TwiML.TwilioResponse();

                twiml.Message(jsonthreearray);
                Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + twiml.ToString());

            }
            else
            {
                string answer = "Not valid location/zip";
                Response.ContentType = "text/xml";
                var twiml = new Twilio.TwiML.TwilioResponse();

                twiml.Message(answer);
                Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + twiml.ToString());

            }









        
        }

    }
}

