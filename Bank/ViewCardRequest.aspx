<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Bank.master" AutoEventWireup="true" CodeFile="ViewCardRequest.aspx.cs" Inherits="Bank_ViewCardRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <em class="fa fa-home"></em>
                </a></li>
                <li class="active">Card Request Details</li>
            </ol>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Card Request Details
                        <span class="pull-right clickable panel-toggle panel-button-tab-left"><em class="fa fa-toggle-up"></em></span>
                    </div>
                    <div class="panel-body">
                        <div class="canvas-wrapper">
                            <asp:Button Text="Excel" CssClass="btn btn-success pull-right btn-block" OnClick="btnExcel_Click" ID="btnExcel" runat="server" />
                            <asp:GridView ID="grdView" CssClass="table table-hover table-dark table-striped" OnRowCommand="grdView_RowCommand" OnRowDataBound="grdView_RowDataBound" runat="server">
                                <Columns>
                                       <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Accept" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-success" ID="btnAccept" Text="Accept" CommandName="Accept" CommandArgument='<%#Eval("Accno")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reject" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-danger" ID="btnreject" Text="Reject" CommandName="Reject" CommandArgument='<%#Eval("Accno")%>' runat="server" />
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





