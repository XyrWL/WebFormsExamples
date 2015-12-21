<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sandbox.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <asp:Panel ID="ShowHidePanel" runat="server" GroupingText="Link generator">
                <asp:Label ID="LinkLabel" runat="server" Text="Type an url:"></asp:Label>
                <asp:TextBox ID="LinkTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="TextToLinkButton" runat="server" Text="->" OnClick="TextToLinkButton_OnClick" />
                <asp:HyperLink ID="Link" runat="server" Text="Go to URL"></asp:HyperLink>
            </asp:Panel>
            <asp:Button ID="HideButton" runat="server" Text="Hide" OnClick="HideButton_OnClick" />
            <asp:Button ID="ShowButton" runat="server" Text="Show" Visible="False" OnClick="ShowButton_OnClick" />
             <asp:HyperLink ID="CalculatorLink" runat="server" Text="Go to Calculator" NavigateUrl="Calculator.aspx"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
