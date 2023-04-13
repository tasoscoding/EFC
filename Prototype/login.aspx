<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="LoginPage" %>
<!DOCTYPE html>
<html lang="en-US">
    <head>
        <meta charset="utf-8" />
        <title>EFC - Login</title>
    </head>
    <body>
        <h3>Energy Flow Control</h3>
        <form id="messageform" runat="server">
            <div>
                Password: <span><asp:TextBox ID="passwdbox" runat="server"></asp:TextBox></span>
                <span><asp:Button ID="loginbtn" runat="server" Text="Login" OnClick="login_click" /></span>
            </div>
            <div>
                <asp:Label ID="outputbox" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
