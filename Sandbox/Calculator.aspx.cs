using System;
using System.Web.UI.WebControls;

namespace Sandbox
{
    public partial class Calculator : System.Web.UI.Page
    {
        private bool isAwaitingNextInput;
        private double currentTotal;
        private string currentOperation;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAwaitingNextInput"] != null)
                isAwaitingNextInput = (bool)Session["isAwaitingNextInput"];
            if (Session["currentTotal"] != null)
                currentTotal = (double)Session["currentTotal"];
            if (Session["currentOperation"] != null)
                currentOperation = (string)Session["currentOperation"];
            else
                currentOperation = "=";
        }

        protected void NumberClick(object sender, EventArgs e)
        {
            string numberText = ((Button)sender).Text;
            InputNumber(numberText);
        }
        private void InputNumber(string numberText)
        {
            if (currentOperation == "=")
                TextBoxHistory.Text = "";
            if (isAwaitingNextInput)
            {
                TextBoxInputResult.Text = "0";
                isAwaitingNextInput = false;
            }
            if (TextBoxInputResult.Text == "0" && numberText != ",")
                TextBoxInputResult.Text = numberText;
            else if (!(TextBoxInputResult.Text.Contains(",") && numberText == ","))
                TextBoxInputResult.Text += numberText;

            Session["isAwaitingNextInput"] = isAwaitingNextInput;
        }

        protected void OperationClick(object sender, EventArgs e)
        {
            string newOperation = ((Button)sender).Text;
            InputOperation(newOperation);
        }
        private void InputOperation(string newOperation)
        {
            if (!isAwaitingNextInput || currentOperation == "=")
            {
                double input = double.Parse(TextBoxInputResult.Text);

                switch (currentOperation)
                {
                    case "=":
                        TextBoxHistory.Text = "";
                        currentTotal = input;
                        break;
                    case "+":
                        currentTotal += input;
                        break;
                    case "-":
                        currentTotal -= input;
                        break;
                    case "x":
                        currentTotal *= input;
                        break;
                    case "/":
                        currentTotal /= input;
                        break;
                    default:
                        break;
                }
                TextBoxHistory.Text += TextBoxInputResult.Text;
                AddOperationToHistory(newOperation);
                var isBigNumber = currentTotal > 999999 || currentTotal < -999999;
                var isSmallNumber = currentTotal < 0.0001 & currentTotal > -0.0001;
                if (isBigNumber || isSmallNumber)
                    TextBoxInputResult.Text = $"{currentTotal:E7}";
                else
                    TextBoxInputResult.Text = currentTotal.ToString();

                isAwaitingNextInput = true;
            }
            else
            {
                RemoveLastOperationFromHistory();
                AddOperationToHistory(newOperation);
            }
            currentOperation = newOperation;

            Session["isAwaitingNextInput"] = isAwaitingNextInput;
            Session["currentTotal"] = currentTotal;
            Session["currentOperation"] = currentOperation;
        }

        private void RemoveLastOperationFromHistory()
        {
            TextBoxHistory.Text = TextBoxHistory.Text.Remove(TextBoxHistory.Text.Length - 3);
            if ((currentOperation == "x" || currentOperation == "/") && TextBoxHistory.Text.Split(' ').Length > 1)
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
            currentOperation = "=";

            Session["currentOperation"] = currentOperation;
        }

        protected void PlusMinusClick(object sender, EventArgs e)
        {
            TextBoxInputResult.Text = (double.Parse(TextBoxInputResult.Text) * (-1)).ToString();
        }
    }
}