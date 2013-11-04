using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScopeSearch
{
    public partial class _default : System.Web.UI.Page
    {
        public const string SQLESCAPE = "-'";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (NullReferenceException) { }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Contains("'"))
            {
                TextBox1.Text = "Cannot use the character ' in query";
            }
            else if (TextBox1.Text.Contains("--"))
            {
                TextBox1.Text = "Cannot use the character -- in query";
            }
            else
            {
                if (!CheckBox1.Checked)
                {
                    SqlDataSource1.SelectCommand = "Select qt.QuoteID,c.Name,qt.SignedDate," +
                                                   "'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) + '#' + Cast(qtm.QuoteModuleID as nvarchar(100)) as GearsLink," +
                                                   " 'Scope' as FoundIn" +
                                                   " From ININ_SID.dbo.QT_Quotes qt" +
                                                   " inner join Customers c on" +
                                                   " qt.CustomerID = c.CustomerID" +
                                                   " left join QT_Quotes_Modules qtm" +
                                                   " on qtm.quoteid = qt.quoteid" +
                                                   " Where qt.QuoteID is not null and (Scope like '%" + TextBox1.Text +
                                                   "%' or qt.Name like '%" + TextBox1.Text + "%'  )" +
                                                   " and qtm.ModuleID = 11" +
                                                   " UNION ALL" +
                                                   " Select qtqa.QuoteID, c.Name, qt.SignedDate, " +
                                                   " 'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) as GearsLink, " +
                                                   " 'Assumptions' as FoundIn" +
                                                   " From QT_Quotes_Assumptions qtqa inner join QT_Quotes qt " +
                                                   " on qt.QuoteID = qtqa.QuoteID inner join Customers c " +
                                                   " on qt.CustomerID = c.CustomerID " +
                                                   " WHERE qt.QuoteID is not null and qtqa.assumption like '%" +
                                                   TextBox1.Text + "%' " +
                                                   " UNION ALL" +
                                                   " Select qtqa.QuoteID, c.Name, qt.SignedDate, " +
                                                   " 'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) as GearsLink, " +
                                                   " 'Attributes' as FoundIn" +
                                                   " From QT_Quotes_Attributes_SOWLanguage qtqasl" +
                                                   " inner join QT_Quotes_Attributes qtqa " +
                                                   " on qtqasl.AttributeID = qtqa.AttributeID" +
                                                   " inner join QT_Quotes qt " +
                                                   " on qtqa.QuoteID = qt.QuoteID" +
                                                   " inner join Customers c" +
                                                   " on c.CustomerID = qt.CustomerID" +
                                                   " WHERE qt.QuoteID is not null and (qtqasl.SOWLanguage like '%" +
                                                   TextBox1.Text + "%' " +
                                                   " or qtqa.Name like '%"+ TextBox1.Text+"%' " +
                                                   " or qtqa.DisplayName like '%" + TextBox1.Text + "%' )";
                }
                else
                {
                    SqlDataSource1.SelectCommand = "Select qt.QuoteID,c.Name,qt.SignedDate," +
                                                   "'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) + '#' + Cast(qtm.QuoteModuleID as nvarchar(100)) as GearsLink," +
                                                   " 'Scope' as FoundIn" +
                                                   " From ININ_SID.dbo.QT_Quotes qt" +
                                                   " inner join Customers c on" +
                                                   " qt.CustomerID = c.CustomerID" +
                                                   " left join QT_Quotes_Modules qtm" +
                                                   " on qtm.quoteid = qt.quoteid" +
                                                   " Where qt.QuoteID is not null and (Scope like '%" + TextBox1.Text +
                                                   "%' or qt.Name like '%"+ TextBox1.Text+"%' ) " +
                                                   " and qtm.ModuleID = 11" +
                                                   " and qt.SignedDate is not null" +
                                                   " UNION ALL" +
                                                   " Select qtqa.QuoteID, c.Name, qt.SignedDate, " +
                                                   " 'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) as GearsLink, " +
                                                   " 'Assumptions' as FoundIn" +
                                                   " From QT_Quotes_Assumptions qtqa inner join QT_Quotes qt " +
                                                   " on qt.QuoteID = qtqa.QuoteID inner join Customers c " +
                                                   " on qt.CustomerID = c.CustomerID " +
                                                   " WHERE qt.QuoteID is not null and qtqa.assumption like '%" +
                                                   TextBox1.Text + "%' " +
                                                   " and qt.SignedDate is not null" +
                                                   " UNION ALL" +
                                                   " Select qtqa.QuoteID, c.Name, qt.SignedDate, " +
                                                   " 'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) as GearsLink, " +
                                                   " 'Attributes' as FoundIn" +
                                                   " From QT_Quotes_Attributes_SOWLanguage qtqasl" +
                                                   " inner join QT_Quotes_Attributes qtqa " +
                                                   " on qtqasl.AttributeID = qtqa.AttributeID" +
                                                   " inner join QT_Quotes qt " +
                                                   " on qtqa.QuoteID = qt.QuoteID" +
                                                   " inner join Customers c" +
                                                   " on c.CustomerID = qt.CustomerID" +
                                                  " WHERE qt.QuoteID is not null and (qtqasl.SOWLanguage like '%" +
                                                   TextBox1.Text + "%' " +
                                                   " or qtqa.Name like '%" + TextBox1.Text + "%' " +
                                                   " or qtqa.DisplayName like '%" + TextBox1.Text + "%' )" +
                                                   " and qt.SignedDate is not null";
                }
            }

        }
    }
}