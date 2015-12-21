using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sandbox
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HideButton_OnClick(object sender, EventArgs e)
        {
            HideButton.Visible = false;
            ShowButton.Visible = true;
            ShowHidePanel.Visible = false;
        }

        protected void ShowButton_OnClick(object sender, EventArgs e)
        {
            HideButton.Visible = true;
            ShowButton.Visible = false;
            ShowHidePanel.Visible = true;
        }

        protected void TextToLinkButton_OnClick(object sender, EventArgs e)
        {
            if (LinkTextBox.Text.StartsWith("http://") || LinkTextBox.Text.StartsWith("https://"))
                Link.NavigateUrl = LinkTextBox.Text;
            else
                Link.NavigateUrl = "http://" + LinkTextBox.Text;
        }
    }
}