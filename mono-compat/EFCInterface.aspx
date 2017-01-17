<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EFCInterface.aspx.cs" Inherits="EFCInterface" %>
<!DOCTYPE html>
<html lang="en-US">
    <head>
        <meta charset="utf-8" />
        <title>EFC Interface</title>
    </head>
    <body>
        <h3>Energy Flow Control Interface</h3>
        <form id="messafeform" runat="server">
            <div>
                inputbox: <asp:TextBox ID="inputbox" runat="server"></asp:TextBox><br />
                outputbox: <asp:TextBox ID="outputbox" runat="server"></asp:TextBox><br />
                <asp:Button ID="send" runat="server" Text="Send" OnClick="send_click" /><br />
            </div>
        </form>
    </body>
</html>