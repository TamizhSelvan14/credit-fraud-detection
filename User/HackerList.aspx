<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.master" AutoEventWireup="true" CodeFile="HackerList.aspx.cs" Inherits="User_HackerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Hacker List</li>
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
                        Hacker List
					
                      
                        <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <asp:Button Text="Excel" CssClass="btn btn-success pull-right btn-block" OnClick="btnExcel_Click" ID="btnExcel" runat="server" />

                            <asp:GridView ID="grdView" CssClass="table table-hover table-dark table-striped" OnRowDataBound="grdView_RowDataBound" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/.row-->


    </div>
</asp:Content>