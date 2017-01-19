<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EFCInterface.aspx.cs" Inherits="EFCInterface" %>
<!DOCTYPE html>
<html lang="en-US">
    <head>
        <meta charset="utf-8" />
        <title>EFC Interface</title>
    </head>
    <body>
        <h3>Energy Flow Control Interface</h3>
        <form id="messageform" runat="server">
            <div>
                <span><asp:TextBox ID="inputbox" runat="server"></asp:TextBox></span>
                <span><asp:Button ID="send" runat="server" Text="Send" OnClick="send_click" /></span>
            </div>
            <div>
                <asp:Label ID="outputbox" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
