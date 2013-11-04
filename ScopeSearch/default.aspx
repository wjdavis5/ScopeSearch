<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ScopeSearch._default" MasterPageFile="Master.Master" %>


    <asp:Content runat="server" ContentPlaceHolderID="Head">
        <!--    <script type="text/javascript">
        var showGears = function (url) {
            var tUrl = 'http://gears.inin.com/Quote/Details?id=' + url;
            $.get(tUrl, function(response) {
                $('#gearsPage').html(response);
                $('#gearsPage').fadeIn();
            });
            
        };
       
        
    </script>
    -->
        </asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Body">
     <div class="container theme-showcase">
        <div class="jumbotron">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ININ_SIDConnectionString %>" SelectCommand="Select 		

                                                                                            qt.QuoteID,
                                                                                            c.Name,
                                                                                            qt.SignedDate,
                                                                                            'http://gears.inin.com/Quote/Details?id=' + Cast(qt.QuoteID as nvarchar(100)) as GearsLink,
                                                                                            '' as FoundIn
                                                                                            From ININ_SID.dbo.QT_Quotes qt
                                                                                            inner join Customers c on
                                                                                            qt.CustomerID = c.CustomerID
                                                                                            Where QuoteID = -1">
            
        </asp:SqlDataSource>
    
    
        <h1>Gears Scope Search</h1>
        
        <asp:TextBox type="text" placeholder="Search Gears" CssClass="input-xlarge" required="true" ID="TextBox1" runat="server" style="width: 60%;"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="btn btn-primary btn-lg" />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Only Signed SOWs" />
        
            </div>
    <br/>
    <div style="width:100%">
        <div style="margin: 0 auto;display:table" class="panel panel-primary">
            <div class="panel-heading"><h2 class="panel-title">Results</h2></div>
            <div class="panel-body">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="QuoteID" DataSourceID="SqlDataSource1" PageSize="60" 
                    CssClass="table table-hover table-striped table-bordered table-condensed table-responsive" GridLines="None"
                    RowStyle-CssClass="td"
                    HeaderStyle-CssClass="th" >
                    <Columns>
                        
                        <asp:HyperLinkField  DataNavigateUrlFields="GearsLink" DataTextField="QuoteID" HeaderText="QuoteId" />
                        
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="SignedDate" HeaderText="SignedDate" SortExpression="SignedDate" />
                        <asp:BoundField DataField="FoundIn" HeaderText="FoundIn" ReadOnly="True" SortExpression="FoundIn" />
                        
                    </Columns>
                    <EmptyDataTemplate>
                      <div class="alert alert-danger">  No Records Found</div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <br />
                <div id="gearsPage" class="round "></div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
            </div>
            </div></div>
    </div>
    
        
         
    <div id="footer">
      <div class="container">
        &nbsp;</div>
    </div>
    </asp:Content>
