using System.Web;

namespace Opole.Misc
{
    public static class AuthenticationService
    {
        public static bool IsUserAuthenticated()
        {
            return HttpContext.Current.Session["LoggedIn"] != null && (bool)HttpContext.Current.Session["LoggedIn"];
        }

        public static void StoreUserInSession(UserModel user)
        {
            HttpContext.Current.Session["LoggedIn"] = true;
            HttpContext.Current.Session["UserName"] = user.Username;
            HttpContext.Current.Session["UserId"] = user.UserId;
        }

        public static UserModel GetLoggedInUser()
        {
            var user = new UserModel();

            if (IsUserAuthenticated())
            {
                user.Username = (string)HttpContext.Current.Session["UserName"];
                user.UserId = (int)HttpContext.Current.Session["UserId"];
                user.CredentialsCorrect = true;
            }

            return user;
        }
    }
}