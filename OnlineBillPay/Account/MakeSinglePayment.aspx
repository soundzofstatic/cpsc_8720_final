<%@ Page Title="Make Single Payment" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="MakeSinglePayment.aspx.cs" Inherits="OnlineBillPay.Account.MakeSinglePayment" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <!-- List Payees -->
        <div class="clearfix content">
            <div class="container">
                <!-- Payee Results -->
                <div class="row">
                    <h2>Select Payee to make a payment</h2>
                    <div class="col-xs-12 table-responsive">
                        <asp:GridView ID="GridView1" runat="server"
                            AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="true"
                            DataKeyNames="UserPayeeId"
                            DataSourceID="ObjectDataSource1"
                            OnPreRender="GridView1_PreRender"
                            OnRowCommand="GridView1_PayeeResultCommand"
                            CssClass="table table-bordered table-condensed table-hover"
                            PageSize="20"
                            AllowPaging="true">
                            <Columns>
                                <asp:BoundField DataField="Nickname" HeaderText="Payee"
                                    SortExpression="Type">
                                    <ItemStyle CssClass="" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="button"
                                    CommandName="Select"
                                    ControlStyle-CssClass="btn btn-outline-primary"
                                    Text="Make Payment" />
                            </Columns>
                            <AlternatingRowStyle CssClass="altRow" />
                            <EditRowStyle CssClass="warning" />
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                            DataObjectTypeName="UserPayee"
                            SelectMethod="GetUserPayees"
                            TypeName="UserPayeeDb">
                            <SelectParameters>
                                <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
