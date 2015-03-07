<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="yqltext2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4> To Number:</h4>
        <asp:TextBox ID="ToNumber" runat="server"></asp:TextBox>
        <h4>SMS message</h4>
        <asp:TextBox ID="Message" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SendMessage" runat="server" Text="Send Message" OnClick="SendMessage_OnClick" />
    </div>
    </form>
</body>
</html>
