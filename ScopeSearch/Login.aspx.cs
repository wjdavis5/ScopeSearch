using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScopeSearch
{
    public partial class Login : System.Web.UI.Page
    {
        protected bool _loginFailed;

        protected string failedMessage;
           
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _loginFailed = (bool) Session["LoginFailed"];
                if (_loginFailed)
                {
                    failedMessage =
                        "<div id=\"failedDiv\" class=\"alert alert-danger\"><h3>Login Failed!</h3></div>";
                }
                else
                {
                    failedMessage = "";
                }
            }catch(Exception){}
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (LdapAuthentication.IsAuthenticated("", Username.Text, Pwd.Text))
            {
                Session.Add("isAuth", true);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session.Add("isAuth", false);
                Session.Add("LoginFailed",true);
                Response.Redirect("Default.aspx");
            }

        }
    }


    public static class LdapAuthentication
    {



        public static bool IsAuthenticated(string domain, string username, string pwd)
        {
            if (username.Contains("\\"))
            {
                if (username.Split('\\').Count() > 1)
                {
                    username = username.Split('\\')[1]; //if the domain was included strip it out.
                    domain = username.Split('\\')[0];
                }
                else return false;
            }
            string domainAndUsername = domain+ "\\" + username;
            DirectoryEntry entry = new DirectoryEntry("LDAP://i3domain.inin.com/DC=i3domain,DC=inin,DC=com", domainAndUsername, pwd);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

                //Update the new path to the user in the directory.

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }



    }

}