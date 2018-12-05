<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineBillPay.Account.Admin.Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <!-- User -->
        <div class="clearfix content">
            <div class="container">
                <div class="row">
                    <div class="form-horizontal">
                        <div id="successAlerts" class="alert alert-success" role="alert" runat="server" visible="false">
                            <p runat="server" id="pNotification" />
                        </div>
                    </div>

                </div>
                <div class="row">
                    <!-- Toggle User Account State -->
                    <div class="row">
                        <div class="col-xs-12 table-responsive">
                            <h2>Manage Users</h2>
                            <!-- Search Results -->
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true"
                                DataKeyNames="UserId"
                                DataSourceID="ObjectDataSource1"
                                OnPreRender="GridView1_PreRender"
                                OnRowCommand="GridView1_UserResultCommand"
                                OnRowDataBound="GridView1_RowDataBound"
                                CssClass="table table-bordered table-condensed table-hover"
                                PageSize="20"
                                AllowPaging="true">
                                <Columns>
                                     <asp:BoundField DataField="Username" HeaderText="Username">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AccountState" HeaderText="Account Status">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="button"
                                        CommandName="ToggleAccountState"
                                        ControlStyle-CssClass="btn btn-outline-danger"
                                        Text="Toggle" />
                                </Columns>
                                <AlternatingRowStyle CssClass="altRow" />
                                <EditRowStyle CssClass="warning" />
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                                DataObjectTypeName="UserContext"
                                SelectMethod="GetSystemUsers"
                                TypeName="UserContextDb"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <!-- Toggle User Admin -->
                    <div class="row">
                        <div class="col-xs-12 table-responsive">
                            <h2>Add Admin Users</h2>
                            <!-- Search Results -->
                            <asp:GridView ID="GridView2" runat="server"
                                AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true"
                                DataKeyNames="UserId"
                                DataSourceID="ObjectDataSource2"
                                OnPreRender="GridView2_PreRender"
                                OnRowCommand="GridView2_UserResultCommand"
                                OnRowDataBound="GridView2_RowDataBound"
                                CssClass="table table-bordered table-condensed table-hover"
                                PageSize="20"
                                AllowPaging="true">
                                <Columns>
                                     <asp:BoundField DataField="Username" HeaderText="Username">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Role" HeaderText="Role">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="button"
                                        CommandName="ToggleAdminRole"
                                        ControlStyle-CssClass="btn btn-outline-danger"
                                        Text="Toggle" />
                                </Columns>
                                <AlternatingRowStyle CssClass="altRow" />
                                <EditRowStyle CssClass="warning" />
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource2"
                                DataObjectTypeName="UserContext"
                                SelectMethod="GetSystemUsers"
                                TypeName="UserContextDb"></asp:ObjectDataSource>
                        </div>
                    </div>
                </div>

                <div class="row">
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
