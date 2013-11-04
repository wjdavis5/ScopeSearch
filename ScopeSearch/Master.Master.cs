using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScopeSearch
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["isAuth"] != null)
            {
                string isAuth = Session["isAuth"].ToString();
                if (isAuth.ToLower() != "true") 
                    Response.Redirect("Login.aspx");
            }
            else Response.Redirect("Login.aspx");
        }
    }
             
}