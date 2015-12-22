using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sandbox
{
    public partial class Calculator : System.Web.UI.Page
    {
        private bool IsAwaitingNextInput { get; set; }
        private double CurrentTotal { get; set; }
        private string CurrentOperation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAwaitingNextInput"] != null)
                IsAwaitingNextInput = (bool)Session["IsAwaitingNextInput"];
            if (Session["CurrentTotal"] != null)
                CurrentTotal = (double)Session["CurrentTotal"];
            if (Session["CurrentOperation"] != null)
                CurrentOperation = (string)Session["CurrentOperation"];
            else
                CurrentOperation = "=";
        }

        protected void NumberClick(object sender, EventArgs e)
        {
            string numberText = ((Button)sender).Text;
            InputNumber(numberText);
        }
        private void InputNumber(string numberText)
        {
            if (CurrentOperation == "=")
                TextBoxHistory.Text = "";
            if (IsAwaitingNextInput)
            {
                TextBoxInputResult.Text = "0";
                IsAwaitingNextInput = false;
            }
            if (TextBoxInputResult.Text == "0" && numberText != ",")
                TextBoxInputResult.Text = numberText;
            else if (!(TextBoxInputResult.Text.Contains(",") && numberText == ","))
                TextBoxInputResult.Text += numberText;

            Session["IsAwaitingNextInput"] = IsAwaitingNextInput;
        }

        protected void OperationClick(object sender, EventArgs e)
        {
            string newOperation = ((Button)sender).Text;
            InputOperation(newOperation);
        }
        private void InputOperation(string newOperation)
        {
            if (!IsAwaitingNextInput || CurrentOperation == "=")
            {
                double input = double.Parse(TextBoxInputResult.Text);

                switch (CurrentOperation)
                {
                    case "=":
                        TextBoxHistory.Text = "";
                        CurrentTotal = input;
                        break;
                    case "+":
                        CurrentTotal += input;
                        break;
                    case "-":
                        CurrentTotal -= input;
                        break;
                    case "x":
                        CurrentTotal *= input;
                        break;
                    case "/":
                        CurrentTotal /= input;
                        break;
                    default:
                        break;
                }
                TextBoxHistory.Text += TextBoxInputResult.Text;
                AddOperationToHistory(newOperation);
                var isBigNumber = CurrentTotal > 999999 || CurrentTotal < -999999;
                var isSmallNumber = CurrentTotal < 0.0001 & CurrentTotal > -0.0001;
                if (isBigNumber || isSmallNumber)
                    TextBoxInputResult.Text = $"{CurrentTotal:E7}";
                else
                    TextBoxInputResult.Text = CurrentTotal.ToString();

                IsAwaitingNextInput = true;
            }
            else
            {
                RemoveLastOperationFromHistory();
                AddOperationToHistory(newOperation);
            }
            CurrentOperation = newOperation;

            Session["IsAwaitingNextInput"] = IsAwaitingNextInput;
            Session["CurrentTotal"] = CurrentTotal;
            Session["CurrentOperation"] = CurrentOperation;
        }

        private void RemoveLastOperationFromHistory()
        {
            TextBoxHistory.Text = TextBoxHistory.Text.Remove(TextBoxHistory.Text.Length - 3);
            if ((CurrentOperation == "x" || CurrentOperation == "/") && TextBoxHistory.Text.Split(' ').Length > 1)
            {
                TextBoxHistory.Text = TextBoxHistory.Text.Remove(TextBoxHistory.Text.Length - 1);
                TextBoxHistory.Text = TextBoxHistory.Text.Remove(0, 1);
            }
        }
        private void AddOperationToHistory(string newOperation)
        {
            if ((newOperation == "x" || newOperation == "/") && TextBoxHistory.Text.Split(' ').Length > 1)
                TextBoxHistory.Text = "(" + TextBoxHistory.Text + ")";
            TextBoxHistory.Text += " " + newOperation + " ";
        }

        protected void BackClick(object sender, EventArgs e)
        {
            InputBack();
        }
        private void InputBack()
        {
            if (TextBoxInputResult.Text.Length > 1)
                TextBoxInputResult.Text = TextBoxInputResult.Text.Remove(TextBoxInputResult.Text.Length - 1);
            else
                TextBoxInputResult.Text = "0";
        }

        protected void ClearCurrentClick(object sender, EventArgs e)
        {
            TextBoxInputResult.Text = "0";
        }

        protected void ClearAllClick(object sender, EventArgs e)
        {
            InputClearAll();
        }
        private void InputClearAll()
        {
            TextBoxHistory.Text = "";
            TextBoxInputResult.Text = "0";
            CurrentOperation = "=";

            Session["CurrentOperation"] = CurrentOperation;
        }

        protected void PlusMinusClick(object sender, EventArgs e)
        {
            TextBoxInputResult.Text = (double.Parse(TextBoxInputResult.Text) * (-1)).ToString();
        }
    }
}