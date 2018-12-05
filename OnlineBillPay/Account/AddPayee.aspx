<%@ Page Title="Add a Payee" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="AddPayee.aspx.cs" Inherits="OnlineBillPay.Account.AddPayee" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <!-- Search Payee -->
        <div class="clearfix content">
            <div class="container">
                <!--  Search Name -->
                <div class="form-horizontal">
                    <h3>Search for Payees</h3>
                    <hr />
                    <asp:Label runat="server" AssociatedControlID="txtSearchQuery" CssClass="col-md-12 control-label">Payee Name</asp:Label>
                    <div class="form-row align-items-center">
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtSearchQuery" CssClass="form-control col" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button runat="server" OnClick="SearchPayee_Click" ValidationGroup="SearchPayee" Text="Search Payee" CssClass="btn btn-primary" />
                        </div>
                        <div class="col-md-12">
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="txtSearchQuery"
                                ValidationGroup="SearchPayee"
                                CssClass="text-danger" ErrorMessage="Search query cannot be blank." />
                        </div>
                    </div>
                </div>
                <!-- Search Results -->
                <div class="row">
                    <div class="col-xs-12 table-responsive">
                        <asp:GridView ID="GridView1" runat="server"
                            AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="true"
                            DataKeyNames="PayeeId"
                            DataSourceID="ObjectDataSource1"
                            OnPreRender="GridView1_PreRender"
                            OnRowCommand="GridView1_PayeeResultCommand"
                            CssClass="table table-bordered table-condensed table-hover"
                            PageSize="5"
                            AllowPaging="true">
                            <Columns>
                                <asp:BoundField DataField="DefaultName" HeaderText="Type"
                                    SortExpression="Type">
                                    <ItemStyle CssClass="" />
                                </asp:BoundField>

                                <asp:ButtonField ButtonType="button"
                                    CommandName="Select"
                                    ControlStyle-CssClass="btn btn-outline-primary"
                                    Text="Select" />
                            </Columns>
                            <AlternatingRowStyle CssClass="altRow" />
                            <EditRowStyle CssClass="warning" />
                        </asp:GridView>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                            DataObjectTypeName="Payee"
                            SelectMethod="GetPayeeByName"
                            TypeName="PayeeDb">
                            <SelectParameters>
                                <asp:ControlParameter Name="SearchQuery" Type="String" ControlID="txtSearchQuery" PropertyName="Text" DefaultValue="null" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
        <!-- New Payee Info -->
        <div class="clearfix content">
            <div class="container">
                <!-- Review of Errors -->
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>

                <div class="form-horizontal">
                    <h3>Payee Information</h3>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <!--  Payee Name -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col control-label">Payee Name</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtName"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="Nickname is required." />
                            </div>
                        </div>
                    </div>
                    <!--  Payee Nickname -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtNickname" CssClass="col control-label">Nickname</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtNickname" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNickname"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="Nickname is required." />
                            </div>
                        </div>
                    </div>
                    <!--  Account Number -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtAccountNumber" CssClass="col control-label">Account Number</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtAccountNumber" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAccountNumber"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="Account Number is required." />
                            </div>
                        </div>
                    </div>
                    <!--  Street Addresses -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtStreetAddress" CssClass="col control-label">Street Address</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtStreetAddress" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStreetAddress"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="Street Address is required." />
                            </div>
                        </div>
                    </div>
                    <!--  Street Addresses 2 -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtStreetAddress2" CssClass="col control-label">Street Address Contd.</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtStreetAddress2" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- City, State, Country -->
                    <div class="form-row">
                        <!-- City -->
                        <div class="form-group col-md-5">
                            <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col control-label">City</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="The city field is required." />
                            </div>
                        </div>
                        <!-- Region -->
                        <div class="form-group col-md-4">
                            <asp:Label runat="server" AssociatedControlID="ddlRegion" CssClass="col control-label">State</asp:Label>
                            <div class="col">
                                <asp:DropDownList ID="ddlRegion" runat="server"
                                    CssClass="form-control">
                                    <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRegion"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="The state field is required." />

                            </div>
                        </div>
                        <!-- Country -->
                        <div class="form-group col-md-3">
                            <asp:Label runat="server" AssociatedControlID="ddlCountry" CssClass="col control-label">Country</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="ddlCountry" CssClass="form-control" ReadOnly Text="USA" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCountry"
                                    CssClass="text-danger" ErrorMessage="Country is required." />
                            </div>
                        </div>
                    </div>
                    <!-- Postal Code -->
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label runat="server" AssociatedControlID="txtPostalCode" CssClass="col control-label">Postal Code</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtPostalCode" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPostalCode"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="The postal code field is required." />
                            </div>
                        </div>
                    </div>
                    <!-- Submit/Cancel BTN -->
                    <div class="form-group col-md-12">
                        <div class="btn-group inline">
                            <!-- Hidden input -->
                            <asp:HiddenField runat="server" ID="hdnExistingPayeeId" Value="" />
                            <asp:HiddenField runat="server" ID="hdnRegionDDLVal" Value="" />
                            <div class="col-md-offset-2">
                                <asp:Button runat="server" OnClick="CreatePayee_Click" Text="Add Payee" ValidationGroup="AddPayeeForm" CssClass="btn btn-primary mr-2" />
                            </div>
                            <div class="col-md-offset-2">
                                <asp:Button runat="server" OnClick="CancelPayee_Click" Text="Cancel" CssClass="btn btn-outline-danger" />
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
        </div>
    </div>
</asp:Content>
