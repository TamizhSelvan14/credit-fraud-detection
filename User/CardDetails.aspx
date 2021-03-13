<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="CardDetails.aspx.cs" Inherits="User_CardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Card Details</li>
            </ol>
        </div>
        <!--/.row-->

        <%--  <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Bank Details</h1>
            </div>
        </div>--%>
        <!--/.row-->


        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Card Details
					
                      
                        <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <table class="table table-hover">
                                <tr>
                                    <th colspan="3">
                                        <asp:Label Text="" ID="lblMessage" runat="server" />
                                    </th>
                                </tr>
                                <tr>
                                    <td>Card No</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblCardNo" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>CVV No</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblCvvNo" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>Exp date</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblExp_date" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>Given Date</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblGiven_date" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>Acc No</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblAccno" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>Card Limit</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblCard_limit" runat="server" /></td>

                                </tr>

                            </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->


    </div>
</asp:Content>



