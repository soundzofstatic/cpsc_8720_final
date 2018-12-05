<%@ Page Title="Phone Numbers" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="PhoneNumbers.aspx.cs" Inherits="OnlineBillPay.Account.PhoneNumbers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>

            <!-- Existing PhoneNumbers Records -->
            <div class="row">
                <div class="col-xs-12 table-responsive">
                    <h2>Existing Phone Numbers</h2>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true"
                        DataKeyNames="PhoneNumberId"
                        DataSourceID="ObjectDataSource1"
                        OnPreRender="GridView1_PreRender"
                        OnRowDeleted="GridView1_RowDeleted"
                        OnRowUpdated="GridView1_RowUpdated"
                        CssClass="table table-bordered table-condensed table-hover"
                        PageSize="5"
                        AllowPaging="true">
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
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1"
                        DataObjectTypeName="PhoneNumber"
                        DeleteMethod="DeletePhoneNumber"
                        OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetPhoneNumbers"
                        TypeName="PhoneNumberDb"
                        UpdateMethod="UpdatePhoneNumber"
                        ConflictDetection="CompareAllValues"
                        OnDeleted="ObjectDataSource1_GetAffectedRows"
                        OnUpdated="ObjectDataSource1_GetAffectedRows">
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
                            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server"
                                Display="Dynamic"
                                CssClass="text-danger"
                                ValidationExpression="\d{10}|((\(\d{3}\))|(\d{3})|(\d{6}))(|[\s.-])((\d{3}[\s.-]\d{4})|(\d{7})|(\d{4}))"
                                ControlToValidate="txtNumber">Must be a valid US Phone Number</asp:RegularExpressionValidator>
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
                <asp:Label ID="lblError" runat="server" EnableViewState="false"
                    CssClass="text-danger"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
