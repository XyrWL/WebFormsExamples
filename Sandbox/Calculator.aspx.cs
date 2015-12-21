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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NumberClick(object sender, EventArgs e)
        {
            string numberText = ((Button)sender).Text;
            InputNumber(numberText);
        }
        private void InputNumber(string numberText)
        {
            if (StateSaver.CurrentOperation == "=")
                TextBoxHistory.Text = "";
            if (StateSaver.IsAwaitingNextInput)
            {
                TextBoxInputResult.Text = "0";
                StateSaver.IsAwaitingNextInput = false;
            }
            if (TextBoxInputResult.Text == "0" && numberText != ",")
                TextBoxInputResult.Text = numberText;
            else if (!(TextBoxInputResult.Text.Contains(",") && numberText == ","))
                TextBoxInputResult.Text += numberText;
        }

        protected void OperationClick(object sender, EventArgs e)
        {
            string newOperation = ((Button)sender).Text;
            InputOperation(newOperation);
        }
        private void InputOperation(string newOperation)
        {
            if (!StateSaver.IsAwaitingNextInput || StateSaver.CurrentOperation == "=")
            {
                double input = double.Parse(TextBoxInputResult.Text);

                switch (StateSaver.CurrentOperation)
                {
                    case "=":
                        TextBoxHistory.Text = "";
                        StateSaver.CurrentTotal = input;
                        break;
                    case "+":
                        StateSaver.CurrentTotal += input;
                        break;
                    case "-":
                        StateSaver.CurrentTotal -= input;
                        break;
                    case "x":
                        StateSaver.CurrentTotal *= input;
                        break;
                    case "/":
                        StateSaver.CurrentTotal /= input;
                        break;
                    default:
                        break;
                }
                TextBoxHistory.Text += TextBoxInputResult.Text;
                AddOperationToHistory(newOperation);
                var isBigNumber = StateSaver.CurrentTotal > 999999 || StateSaver.CurrentTotal < -999999;
                var isSmallNumber = StateSaver.CurrentTotal < 0.0001 & StateSaver.CurrentTotal > -0.0001;
                if (isBigNumber || isSmallNumber)
                    TextBoxInputResult.Text = $"{StateSaver.CurrentTotal:E7}";
                else
                    TextBoxInputResult.Text = StateSaver.CurrentTotal.ToString();

                StateSaver.IsAwaitingNextInput = true;
            }
            else
            {
                RemoveLastOperationFromHistory();
                AddOperationToHistory(newOperation);
            }
            StateSaver.CurrentOperation = newOperation;
        }

        private void RemoveLastOperationFromHistory()
        {
            TextBoxHistory.Text = TextBoxHistory.Text.Remove(TextBoxHistory.Text.Length - 3);
            if ((StateSaver.CurrentOperation == "x" || StateSaver.CurrentOperation == "/") && TextBoxHistory.Text.Split(' ').Length > 1)
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
            StateSaver.CurrentOperation = "=";
        }

        protected void PlusMinusClick(object sender, EventArgs e)
        {
            TextBoxInputResult.Text = (double.Parse(TextBoxInputResult.Text) * (-1)).ToString();
        }
    }
}