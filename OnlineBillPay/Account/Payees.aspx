<%@ Page Title="Manage Payees" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Payees.aspx.cs" Inherits="OnlineBillPay.Account.Payees" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <!-- Funsing Sources -->
    <div class="col-md-9 white-bg">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <!-- Existing FundingSources Records -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <h2>Existing Payees</h2>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="UserPayeeId"
                        DataSourceID="ObjectDataSource1"
                        OnPreRender="GridView1_PreRender"
                        OnRowDeleted="GridView1_RowDeleted"
                        CssClass="table table-bordered table-condensed table-hover"
                        PageSize="5"
                        AllowPaging="true">
                        <Columns>
                            <asp:BoundField DataField="Nickname" HeaderText="Nickname">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PayeeAccountNumber" HeaderText="Account Number">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Link" HeaderText="Delete" CausesValidation="false"
                                ShowDeleteButton="true">
                                <ItemStyle CssClass="" />
                            </asp:CommandField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altRow" />
                        <EditRowStyle CssClass="warning" />
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                        DataObjectTypeName="UserPayee"
                        DeleteMethod="DeleteUserPayee"
                        SelectMethod="GetUserPayees"
                        TypeName="UserPayeeDb"
                        OnDeleted="ObjectDataSource1_GetAffectedRows">
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
