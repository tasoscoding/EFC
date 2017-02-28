using System;
using System.Web.UI;

public partial class LoginPage: Page
{
    protected void login_click(object sender, EventArgs e)
    {
        if (passwdbox.Text == "0000") {
            Response.BufferOutput = true;
            Response.Redirect ("EFCInterface.aspx");
        } else {
            passwdbox.Text = "";
            outputbox.Text = "Invalid password";
        }
    }
}
