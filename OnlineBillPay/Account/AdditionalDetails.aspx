<%@ Page Title="Additional Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdditionalDetails.aspx.cs" Inherits="OnlineBillPay.Account.AdditionalDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section class="wellcome_area regular_hero clearfix" id="account-register">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12 col-md">
                    <div class="wellcome-heading">
                        <h2><%: Title %>.</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Addresses -->
    <section class="clearfix content">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <!-- Existing Address Records -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <h2>Existing Addresses</h2>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="AddressId"
                        DataSourceID="ObjectDataSource1"
                        OnPreRender="GridView1_PreRender"
                        OnRowDeleted="GridView1_RowDeleted"
                        OnRowUpdated="GridView1_RowUpdated"
                        CssClass="table table-bordered table-condensed table-hover">
                        <Columns>
                            <asp:BoundField DataField="StreetAddress" HeaderText="Street Address"
                                SortExpression="StreetAddress">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderText="Type"
                                SortExpression="Type">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Number" HeaderText="Number"
                                SortExpression="Number">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="City" HeaderText="City"
                                SortExpression="City">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PostalCode" HeaderText="Postal Code"
                                SortExpression="PostalCode">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region" HeaderText="Region"
                                SortExpression="Region">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Country" HeaderText="Country"
                                SortExpression="Country">
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
                        DataObjectTypeName="Address"
                        DeleteMethod="DeleteAddress"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetAddresses"
                        TypeName="AddressDb"
                        UpdateMethod="UpdateAddress"
                        ConflictDetection="CompareAllValues"
                        OnDeleted="ObjectDataSource1_GetAffectedRows"
                        OnUpdated="ObjectDataSource1_GetAffectedRows">
                        <SelectParameters>
                            <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="original_address" Type="Object"></asp:Parameter>
                            <asp:Parameter Name="address" Type="Object"></asp:Parameter>
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>

            <div class="form-horizontal">
                <h3>Add an address to your account</h3>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <!-- Primary Street Addresses -->
                <div class="form-row">
                    <div class="form-group col-md-8">
                        <asp:Label runat="server" AssociatedControlID="txtStreetAddress" CssClass="col control-label">Street Address</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtStreetAddress" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStreetAddress"
                                CssClass="text-danger" ErrorMessage="Street Address is required." />
                        </div>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="ddlAddressType" CssClass="col control-label">Address Type</asp:Label>
                        <div class="col">
                            <asp:DropDownList ID="ddlAddressType" runat="server"
                                CssClass="form-control">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtSuiteNumber" CssClass="col control-label">Suite Number</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtSuiteNumber" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <!-- City, State, Country -->
                <div class="form-row">
                    <div class="form-group col-md-5">
                        <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col control-label">City</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity"
                                CssClass="text-danger" ErrorMessage="The city field is required." />
                        </div>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:Label runat="server" AssociatedControlID="ddlRegion" CssClass="col control-label">State</asp:Label>
                        <div class="col">
                            <asp:DropDownList ID="ddlRegion" runat="server"
                                CssClass="form-control">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRegion"
                                CssClass="text-danger" ErrorMessage="The state field is required." />

                        </div>
                    </div>
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
                                CssClass="text-danger" ErrorMessage="The postal code field is required." />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateAddress_Click" Text="Add Address" CssClass="btn btn-default" />
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
    </section>

    <!-- Phone Numbers -->
    <section class="clearfix content">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="Literal1" />
            </p>

            <!-- Existing PhoneNumbers Records -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <h2>Existing Phone Numbers</h2>
                    <asp:GridView ID="GridView2" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="PhoneNumberId"
                        DataSourceID="ObjectDataSource2"
                        OnPreRender="GridView2_PreRender"
                        OnRowDeleted="GridView2_RowDeleted"
                        OnRowUpdated="GridView2_RowUpdated"
                        CssClass="table table-bordered table-condensed table-hover">
                        <Columns>
                            <asp:BoundField DataField="Type" HeaderText="Type"
                                SortExpression="Type">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Number" HeaderText="Number"
                                SortExpression="Number">
                                <ItemStyle CssClass="" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Extension" HeaderText="Extension"
                                SortExpression="Extension">
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
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource2"
                        DataObjectTypeName="PhoneNumber"
                        DeleteMethod="DeletePhoneNumber"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetPhoneNumbers"
                        TypeName="PhoneNumberDb"
                        UpdateMethod="UpdatePhoneNumber"
                        ConflictDetection="CompareAllValues"
                        OnDeleted="ObjectDataSource2_GetAffectedRows"
                        OnUpdated="ObjectDataSource_GetAffectedRows">
                        <SelectParameters>
                            <asp:Parameter Name="UserId" Type="String" DefaultValue="null" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="original_phoneNumber" Type="Object"></asp:Parameter>
                            <asp:Parameter Name="phoneNumber" Type="Object"></asp:Parameter>
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <div class="form-horizontal">
                <h3>Add a phone number to your account</h3>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
                <!-- Number, Type, Extension -->
                <div class="form-row">
                    <div class="form-group col-md-8">
                        <asp:Label runat="server" AssociatedControlID="txtNumber" CssClass="col control-label">Phone Numer</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtNumber" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumber"
                                CssClass="text-danger" ErrorMessage="Phone Numberis required." />
                        </div>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="ddlType" CssClass="col control-label">Phone Type</asp:Label>
                        <div class="col">
                            <asp:DropDownList ID="ddlType" runat="server"
                                CssClass="form-control">
                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtExtension" CssClass="col control-label">Extension</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtExtension" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreatePhoneNumber_Click" Text="Add Phone number" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <p>
                <asp:Label ID="Label1" runat="server" EnableViewState="false"
                    CssClass="text-danger"></asp:Label>
            </p>
        </div>
    </section>

</asp:Content>
