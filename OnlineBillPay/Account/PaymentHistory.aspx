<%@ Page Title="Payment History" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="OnlineBillPay.Account.PaymentHistory" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <!-- Payment History -->
    <div class="col-md-9 white-bg">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <!-- Payment History -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <h2>Payment History</h2>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="PaymentId"
                        DataSourceID="ObjectDataSource1"
                        OnPreRender="GridView1_PreRender"
                        PageSize="15"
                        AllowPaging="true"
                        AllowSorting="true"
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
                        <PagerSettings
                            FirstPageText="First"
                            LastPageText="Last"/>
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                        DataObjectTypeName="Payment"
                        SelectMethod="GetPayments"
                        SortParameterName="sort"
                        TypeName="PaymentDb">
                        <SelectParameters>
                            <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
        <div class="row">
            <p>
                <asp:Label ID="lblError" runat="server" EnableViewState="false"
                    CssClass="text-danger"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
