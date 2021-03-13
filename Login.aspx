<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/datepicker3.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">
</head>
<body style="background-image:url('Home/images/SignIn.jpg');background-repeat:no-repeat;display: block;background-size: cover;">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">Log in</div>
                    <div class="panel-body">
                        <fieldset>
                            <div class="form-group">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" autofocus="" />
                                <%--<input class="form-control" placeholder="E-mail" name="email" type="email" autofocus="">--%>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />

                            </div>
                            <asp:Button Text="Login" runat="server" CssClass="btn btn-success btn-block" ID="btnLogin" OnClick="btnLogin_Click" />
                            <%--<asp:Button Text="Back" runat="server" CssClass="btn btn-danger btn-block" ID="btnBack" OnClick="btnBack_Click" />--%>
                            <a href="index.html" class="btn btn-danger btn-block">Back</a>
                            <asp:HyperLink NavigateUrl="~/Register.aspx" CssClass="btn btn-primary btn-block" ID="hypRegister" Visible="false" Text="Register" runat="server" />
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
