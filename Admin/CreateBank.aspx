<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="CreateBank.aspx.cs" Inherits="Admin_CreateBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Bank Details</li>
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
                        Bank Details
					
                      
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
                                        <asp:DropDownList runat="server" required CssClass="form-control" ID="ddlBankName">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" ID="txtIfsc" placeholder="Ifsc" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" ID="txtBranch" placeholder="Branch Code" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" ID="txtUserName" placeholder="User Name" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" required CssClass="form-control" ID="txtpassword" placeholder="Password" /></td>
                                </tr>
                            </table>

                            <asp:Button Text="Clear" ID="btnClear" CssClass="btn btn-success pull-right" OnClick="btnClear_Click" runat="server" />
                            <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-danger pull-right" OnClick="btnSubmit_Click" runat="server" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->


    </div>
</asp:Content>



