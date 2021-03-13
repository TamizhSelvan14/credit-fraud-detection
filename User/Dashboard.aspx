<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="User_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Dashboard</li>
            </ol>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Dashboard</h1>
            </div>
        </div>
        <!--/.row-->

        <div class="panel panel-container">
            <div class="row">
                <div class="col-xs-12 col-md-6 col-lg-6 no-padding">
                    <div class="panel panel-teal panel-widget border-right">
                        <div class="row no-padding">
                            <em class="fa fa-xl fa-shopping-cart color-blue"></em>
                            <div class="large">
                                <asp:Label Text="" ID="lblAccountNo" runat="server" /></div>
                            <div class="text-muted">Account No</div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-6 col-lg-6 no-padding">
                    <div class="panel panel-blue panel-widget border-right">
                        <div class="row no-padding">
                            <em class="fa fa-xl fa-comments color-orange"></em>
                            <div class="large">
                                <asp:Label Text="" ID="lblStatus" runat="server" /></div>
                            <div class="text-muted">Status</div>
                        </div>
                    </div>
                </div>
               
            </div>
            <!--/.row-->
        </div>

        <!--/.row-->


    </div>
</asp:Content>





