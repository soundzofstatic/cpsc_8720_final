<%@ Page Title="Account Home" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineBillPay.Account.Default" %>

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
                        <h3>Hello,</h3>
                        <p>What would you like to do today?</p>
                    </div>
                </div>
                <div class="row">
                    <!-- Toggle Account Status -->
                    <div class="row">
                        <div class="col-xs-12 table-responsive">
                            <h2>Last 5 Transactions</h2>
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true"
                                DataKeyNames="PaymentId"
                                DataSourceID="ObjectDataSource1"
                                OnPreRender="GridView1_PreRender"
                                CssClass="table table-bordered table-condensed table-hover">
                                <Columns>
                                    <asp:BoundField DataField="Nickname" HeaderText="Payee Name">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:0.00}">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateCreated" HeaderText="Payment Date"
                                        SortExpression="DateCreated">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <ItemStyle CssClass="" />
                                    </asp:BoundField>

                                </Columns>
                                <AlternatingRowStyle CssClass="altRow" />
                                <EditRowStyle CssClass="warning" />
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                                DataObjectTypeName="Payment"
                                SelectMethod="GetPaymentsLatest"
                                TypeName="PaymentDb">
                                <SelectParameters>
                                    <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <a href="PaymentHistory.aspx" title="Full payment history" class="badge badge-primary">See your full payment history</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
