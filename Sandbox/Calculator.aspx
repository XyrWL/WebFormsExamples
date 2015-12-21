<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Sandbox.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxHistory" runat="server" Enabled="False" Width="168"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="TextBoxInputResult" runat="server" Enabled="False" Text="0" Width="168"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonCE" runat="server" Text="CE" Height="40px" OnClick="ClearCurrentClick" Width="40px" />
            <asp:Button ID="ButtonC" runat="server" Text="C" Height="40px" OnClick="ClearAllClick" Width="40px" />
            <asp:Button ID="ButtonBack" runat="server" Text="&lt;=" Height="40px" OnClick="BackClick" Width="40px" />
            <asp:Button ID="ButtonDivide" runat="server" Text="/" Height="40px" OnClick="OperationClick" Width="40px" />
        </div>
        <div>
            <asp:Button ID="Button7" runat="server" Text="7" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button8" runat="server" Text="8" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button9" runat="server" Text="9" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="ButtonMultiply" runat="server" Text="x" Height="40px" OnClick="OperationClick" Width="40px" />
        </div>
        <div>
            <asp:Button ID="Button4" runat="server" Text="4" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button5" runat="server" Text="5" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button6" runat="server" Text="6" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="ButtonSubstract" runat="server" Text="-" Height="40px" OnClick="OperationClick" Width="40px" />
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="1" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button2" runat="server" Text="2" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="Button3" runat="server" Text="3" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="ButtonAdd" runat="server" Text="+" Height="40px" OnClick="OperationClick" Width="40px" />
        </div>
        <div>
            <asp:Button ID="ButtonPlusMinus" runat="server" Text="+/-" Height="40px" OnClick="PlusMinusClick" Width="40px" />
            <asp:Button ID="Button0" runat="server" Text="0" Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="ButtonDecimal" runat="server" Text="," Height="40px" OnClick="NumberClick" Width="40px" />
            <asp:Button ID="ButtonEqual" runat="server" Text="=" Height="40px" OnClick="OperationClick" Width="40px" />
        </div>
    </form>
</body>
</html>
