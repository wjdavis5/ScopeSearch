<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ScopeSearch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LogIn</title>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-2.0.3.min.js"></script>
</head>
<body style="padding-top: 20px">
    <div>
    <div class="container">
    <div class="row">
		<div class="col-md-4 col-md-offset-4">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">Please sign in with domain credentials</h3>
			 	</div>
			  	<div class="panel-body">
			    	<form accept-charset="UTF-8" role="form" runat="server" ID="form1">
                    <fieldset><legend></legend>
			    	  	<div class="form-group">
                             <asp:TextBox ID="Username" class="form-control" placeholder="username" name="email" type="text" runat="server"/>
                              </div>
			    		<div class="form-group">
                            <asp:TextBox ID="Pwd" class="form-control" placeholder="Password" name="password" type="password" value="" runat="server"/>
                            </div>
			    		
                        <asp:Button class="btn btn-lg btn-success btn-block" type="submit" value="Login" runat="server" Text="Login" ID="SubmitButton" OnClick="SubmitButton_Click"/>
</fieldset>
			      	</form>
			    </div>
			</div>
		</div>
	</div>
</div>
    </div>
    
</body>
</html>
