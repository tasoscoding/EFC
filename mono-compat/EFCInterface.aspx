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
                <span><asp:Button ID="statusBtn" runat="server" Text="Status" OnClick="GetEngineStatus" /></span>
                <span><asp:Button ID="startBtn" runat="server" Text="Start" OnClick="StartEngine" /></span>
                <span><asp:Button ID="stopBtn" runat="server" Text="Stop" OnClick="StopEngine" /></span>
                <span><asp:Button ID="reverseBtn" runat="server" Text="Reverse" OnClick="ReverseEngine" /></span>
                <span><asp:Button ID="haltBtn" runat="server" Text="Emergency Stop" OnClick="EmergencyStopEngine" /></span>
                <span><asp:Button ID="resetBtn" runat="server" Text="Reset Inverter" OnClick="ResetEngine" /></span>
            </div>
            <div>
                Frequency: <span><asp:TextBox ID="freqbox" runat="server"></asp:TextBox></span>Hz
                <span><asp:Button ID="setFreq" runat="server" Text="Set" OnClick="setFreq_click" /></span>
            </div>
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
