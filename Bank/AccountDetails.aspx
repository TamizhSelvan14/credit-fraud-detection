<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Bank.master" AutoEventWireup="true" CodeFile="AccountDetails.aspx.cs" Inherits="Bank_AccountDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Account Details</li>
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
                        Account Details
					
                      
                        <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <table class="table table-hover">
                                <tr>
                                    <th>
                                        <asp:Label Text="" ID="lblMessage" runat="server" />
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtname" runat="server" required placeholder="Account Holder Name" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAccno" runat="server" required placeholder="Account No" CssClass="form-control" /></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtaddress" runat="server" required placeholder="Address" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtadharno" runat="server" required placeholder="Adhar Card Number" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--<asp:TextBox ID="TextBox2" runat="server" placeholder="Credit Card Number" CssClass="form-control" />--%>
                                        <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control">
                                            <asp:ListItem Text="Male" />
                                            <asp:ListItem Text="Female" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtmailid" runat="server" required TextMode="Email" placeholder="Mail id" CssClass="form-control" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtphone" runat="server" required TextMode="Number" placeholder="Phone Number" CssClass="form-control" />

                                    </td>
                                </tr>


                                <tr>
                                    <td class="text-right">
                                        <asp:Button Text="Submit" CssClass="btn btn-success" ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" />
                                        <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-danger" OnClick="btnClear_Click" runat="server" />
                                    </td>
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

