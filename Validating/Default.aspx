<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validating.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUsername" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Username is a required field." />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxUsername" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Username must be 3 to 10 alphanumerical characters." ValidationExpression="[a-zA-Z0-9öäåÖÄÅ]{3,10}" />
        </div>
        <div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Password is a required field." />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Password must be 6 to 32 characters." ValidationExpression="(.){6,32}" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxRepeat" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Password validation is required." />
            <asp:CompareValidator runat="server" ControlToValidate="TextBoxRepeat" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Password confirmation invalid." Type="String" ControlToCompare="TextBoxPassword" Operator="Equal" />
        </div>
        <div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAge" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Age is a required field." />
            <asp:CompareValidator runat="server" ControlToValidate="TextBoxAge" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Age must be a number." Type="Integer" Operator="DataTypeCheck" />
            <asp:CompareValidator runat="server" ControlToValidate="TextBoxAge" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Age must be a number of value 18 or higher." Type="Integer" ValueToCompare="18" Operator="GreaterThanEqual" />
        </div>
        <div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxSubscription" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Subscription length is a required field." />
            <asp:CompareValidator runat="server" ControlToValidate="TextBoxSubscription" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Subscription months must be a number." Type="Integer" Operator="DataTypeCheck" />
            <asp:RangeValidator runat="server" ControlToValidate="TextBoxSubscription" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Subscription length must be between 3 to 12 months." Type="Integer" MinimumValue="3" MaximumValue="12"/>
            <asp:CustomValidator runat="server" ControlToValidate="TextBoxSubscription" Display="Dynamic" EnableClientScript="False" ForeColor="Red" ErrorMessage="Subscription length must be in periods of 3 months." OnServerValidate="SubscriptionCustomValidate"/>
        </div>
        <div>
            <label>Username: </label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxUsername"></asp:TextBox>
        </div>
        <div>
            <label>Password: </label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxPassword" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <label>Repeat password: </label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxRepeat" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <label>Age: </label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxAge"></asp:TextBox>
        </div>
        <div>
            <label>Subscription length (months): </label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxSubscription"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="ButtonSubmit" OnClick="ButtonSubmit_OnClick" Text="Submit" /><br />
            <asp:Label runat="server" ID="LabelFeedback"></asp:Label>
        </div>
    </form>
</body>
</html>
