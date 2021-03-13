<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Purchase.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Purchase Details</li>
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
                        Purchase Details
                        <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <table class="table">
                                <tr>
                                    <th>
                                        <asp:Label Text="" ID="lblMessage" runat="server" /></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtIpAddress" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtMachineId" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" TextMode="Number" ID="txtPruchaseAmount" placeholder="Pruchase Amount" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" Visible="false" ID="lblAccountNo" />
                                        <asp:TextBox runat="server" Visible="false" ID="lblMobile" />
                                        <asp:TextBox runat="server" Visible="false" ID="lblmobilealt" />

                                        <asp:TextBox runat="server" Visible="false" ID="lblbackcode1" />

                                        <asp:TextBox runat="server" Visible="false" ID="lblbackcode2" />



                                        <asp:TextBox runat="server" required CssClass="form-control" TextMode="Number" ID="txtCardNo" placeholder="Card No" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" TextMode="Number" ID="txtPassword" placeholder="Password" />
                                        <asp:Button Text="Check Password" CssClass="btn btn-primary pull-right" ID="btnCheckPassword" OnClick="btnCheckPassword_Click" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt1stPassword" Visible="false" placeholder="Password" />
                                        <asp:TextBox runat="server" Visible="false" ID="lbl1stPassword" placeholder="1stPwd" />
                                        <asp:Button Text="1 St Password" CssClass="btn btn-primary pull-right" Visible="false" ID="btn1stPassword" OnClick="btn1stPassword_Click" runat="server" /></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt2stPassword" Visible="false" placeholder="Password" />
                                        <asp:TextBox runat="server" Visible="false" ID="lbl2stPassword" placeholder="1stPwd" />
                                    </td>
                                </tr>
                            </table>

                            <asp:Button Text="Clear" ID="btnClear" Visible="false" CssClass="btn btn-danger pull-right" OnClick="btnClear_Click" runat="server" />
                            <asp:Button Text="Submit" ID="btnSubmit" Visible="false" CssClass="btn btn-success pull-right" OnClick="btnSubmit_Click" runat="server" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->


    </div>
</asp:Content>

