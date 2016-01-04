using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validating
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
                LabelFeedback.Text = "Form was sent!";
            else
                LabelFeedback.Text = "Form was not sent.";
        }

        protected void SubscriptionCustomValidate(object source, ServerValidateEventArgs e)
        {
            int i;
            if (int.TryParse(e.Value, out i))
                e.IsValid = ((i % 3) == 0);
        }
    }
}