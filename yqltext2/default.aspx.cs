using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Twilio;

namespace yqltext2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendMessage_OnClick(object sender, EventArgs e)
        {
            string AccountSid = "ACc4874e6eb392cccb8733c115f81a46dd";
            string AuthToken = "5852d80434a97cb6209d26c32e26be19";

            var client = new TwilioRestClient(AccountSid, AuthToken);

            client.SendSmsMessage("+13238157900", ToNumber.Text, Message.Text, "");

        }
    }
}