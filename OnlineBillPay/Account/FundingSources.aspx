<%@ Page Title="Funding Sources" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FundingSources.aspx.cs" Inherits="OnlineBillPay.Account.FundingSources" %>

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
                    <h2>Existing Funding Sources</h2>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="FundingSourceId"
                        DataSourceID="ObjectDataSource1"
                        OnPreRender="GridView1_PreRender"
                        OnRowDeleted="GridView1_RowDeleted"
                        OnRowUpdated="GridView1_RowUpdated"
                        CssClass="table table-bordered table-condensed table-hover"
                        PageSize="5"
                        AllowPaging="true">
                        <Columns>
                            <asp:BoundField DataField="AccountNumber" HeaderText="Account Number"
                                SortExpression="AccountNumber">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nickname" HeaderText="Nickname"
                                SortExpression="Nickname">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderText="Type"
                                SortExpression="Type">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Link" HeaderText="Edit" CausesValidation="false"
                                ShowEditButton="true">
                                <ItemStyle CssClass="text-danger" />
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Link" HeaderText="Delete" CausesValidation="false"
                                ShowDeleteButton="true">
                                <ItemStyle CssClass="" />
                            </asp:CommandField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altRow" />
                        <EditRowStyle CssClass="warning" />
                    </asp:GridView>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                        DataObjectTypeName="FundingSource"
                        DeleteMethod="DeleteFundingSource"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetFundingSources"
                        TypeName="FundingSourceDb"
                        UpdateMethod="UpdateFundingSource"
                        ConflictDetection="CompareAllValues"
                        OnDeleted="ObjectDataSource1_GetAffectedRows"
                        OnUpdated="ObjectDataSource1_GetAffectedRows">
                        <SelectParameters>
                            <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="original_fundingSource" Type="Object"></asp:Parameter>
                            <asp:Parameter Name="fundingSource" Type="Object"></asp:Parameter>
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="form-horizontal">
                <h3>Add a funding source to your account</h3>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <!-- Number, Type, Extension -->
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="txtAccountNumber" CssClass="col control-label">Account Number</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtAccountNumber" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAccountNumber"
                                CssClass="text-danger" ErrorMessage="Account Number is required." />
                        </div>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:Label runat="server" AssociatedControlID="txtNickname" CssClass="col control-label">Nickname</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNickname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNickname"
                                CssClass="text-danger" ErrorMessage="Account nickname is required." />
                        </div>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col control-label">Account Type</asp:Label>
                        <div class="col">
                            <asp:DropDownList ID="ddlType" runat="server"
                                CssClass="form-control">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateFundingSource_Click" Text="Add Funding source" CssClass="btn btn-default" />
                    </div>
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
