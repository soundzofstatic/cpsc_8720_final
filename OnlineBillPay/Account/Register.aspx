<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineBillPay.Account.Register" %>

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
    <section class="clearfix">
        <div class="container">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <div class="form-horizontal">
                <h4>Create a new account</h4>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
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
                <!-- DisplayName -->
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label runat="server" AssociatedControlID="txtDisplayName" CssClass="col control-label">Display Name</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="txtDisplayName" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <!-- Email -->
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col control-label">Email</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                </div>
                <!-- Password -->
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col control-label">Password</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <!-- Confirm Password -->
                    <div class="form-group  col-md-6">
                        <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col control-label">Confirm password</asp:Label>
                        <div class="col">
                            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
