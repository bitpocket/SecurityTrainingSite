using System;
using System.Drawing;
using Opole.Misc;

namespace Opole.Account
{
    public partial class Login : System.Web.UI.Page
    {
        const string IncorrectLoginMessage = "Failed to login.";

        protected void Page_Load(object sender, EventArgs e)
        {
            UserNameTextBox.Focus();

            if (IsPostBack)
            {
                bool loggedIn = LogIn();
                TakeActionBasedOnLoginResult(loggedIn);
            }
        }

        private bool LogIn()
        {
            UserModel loggedInUser = SqlHelper.LogIn(UserNameTextBox.Text, PasswordTextBox.Text);

            if (loggedInUser.CredentialsCorrect)
            {
                AuthenticationService.StoreUserInSession(loggedInUser);
            }

            return loggedInUser.CredentialsCorrect;
        }

        private void TakeActionBasedOnLoginResult(bool loggedInSuccessfully)
        {
            if (!loggedInSuccessfully)
            {
                ShowIncorrectLoginMessage();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        private void ShowIncorrectLoginMessage()
        {
            LoginResultLabel.ForeColor = Color.Red;
            LoginResultLabel.Text = IncorrectLoginMessage;
        }
    }
}