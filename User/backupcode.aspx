<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="backupcode.aspx.cs" Inherits="User_backupcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">backup code Details</li>
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
                        backup code Details
					
                      
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
                                    <td>Code1</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblcode1" runat="server" /></td>

                                </tr>
                                <tr>
                                    <td>Code2</td>
                                    <td>:</td>
                                    <td>
                                        <asp:Label Text="" ID="lblcode2" runat="server" /></td>

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

