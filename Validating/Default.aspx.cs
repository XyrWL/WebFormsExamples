using System;
using System.Collections.Generic;
using System.Drawing;
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

        protected void SubscriptionCustomValidate(object source, ServerValidateEventArgs e)
        {
            int i;
            if (int.TryParse(e.Value, out i))
                e.IsValid = ((i % 3) == 0);
        }

        protected void ButtonSubmit_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(TryChangeLabelColor(Color.LimeGreen))
                    LabelFeedback.Text = "Form was valid!";
            }
            else
            {
                LabelFeedback.Text = "Form was not valid.";
                LabelFeedback.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// This is a documentation test method that changes the text color of LabelFeedback based on the inparameter.
        /// </summary>
        /// <param name="color">Color used on LabelFeedback's ForeColor property.</param>
        /// <returns>Returns true if changing the color was successful.</returns>        
        private bool TryChangeLabelColor(Color color)
        {
            try
            {
                LabelFeedback.ForeColor = color; //Won't really throw an exception, just an example to give the return value a purpose.
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}