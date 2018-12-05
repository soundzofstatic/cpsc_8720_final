<%@ Page Title="Manage User Details" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="ManageUserDetails.aspx.cs" Inherits="OnlineBillPay.Account.ManageUserDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <!-- Edit User Details -->
        <div class="clearfix content">
            <div class="container">
                <!-- Review of Errors -->
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>

                <div class="form-horizontal">
                    <h3>User Data Information</h3>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <!--  Display Name -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtDisplayName" CssClass="col control-label">Display Name</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtDisplayName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtDisplayName"
                                    ValidationGroup="AddPayeeForm"
                                    CssClass="text-danger" ErrorMessage="Displayname is required." />
                            </div>
                        </div>
                    </div>
                    <!-- First Name & Last Name -->
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col control-label">First Name</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                                    CssClass="text-danger" ErrorMessage="First name is required." />
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="colcontrol-label">Last Name</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                                    CssClass="text-danger" ErrorMessage="Last Name is required." />
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <!-- Email -->
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col control-label">Email</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" ReadOnly="true" />
                            </div>
                        </div>
                        <!-- Username -->
                        <div class="form-group col-md-6">
                            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col control-label">Username</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" TextMode="Email" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <!-- Submit/Cancel BTN -->
                    <div class="form-group col-md-12">
                        <div class="btn-group inline">
                            <div class="col-md-offset-2">
                                <asp:Button runat="server" OnClick="UpdateUser_Click" Text="Update User Details" CssClass="btn btn-primary mr-2" />
                            </div>
                            <div class="col-md-offset-2">
                                <asp:Button runat="server" OnClick="CancelUpdateUser_Click" Text="Cancel" CssClass="btn btn-outline-danger" />
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
