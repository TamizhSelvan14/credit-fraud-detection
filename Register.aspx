<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Sign Up</title>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/datepicker3.css" rel="stylesheet"/>
    <link href="css/styles.css" rel="stylesheet"/>
  
</head>
<body style="background-image:url('Home/images/SignIn.jpg');background-repeat:no-repeat;display: block;background-size: cover;">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">Sign Up</div>
                    <div class="panel-body">
                        <fieldset>

                             <div class="form-group">
                                 <asp:Label Text="" ID="lblMessage" runat="server" />
                             </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtAccountNo" required runat="server" CssClass="form-control" placeholder="Account No" TextMode="Password"  autofocus="" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtMobileNo" required runat="server" CssClass="form-control" placeholder="Mobile No" TextMode="Number" />

                            </div>
                            <asp:Button Text="Request Username" runat="server" CssClass="btn btn-success btn-block" ID="btnLogin" OnClick="btnLogin_Click" />
                            <a href="index.html" class="btn btn-danger btn-block">Back</a>
                           
                        </fieldset>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </div>
        <!-- /.row -->

        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>
