<%@ Page Title="Payment" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="OnlineBillPay.Account.Payment" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="NestedContent">
    <div class="col-md-9 white-bg">
        <!-- Payment info -->
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
                    <!--  UserPayee Nickname -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtNickname" CssClass="col control-label">Nickname</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtNickname" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <!--  Account Number -->
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="txtAccountNumber" CssClass="col control-label">Account Number</asp:Label>
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtAccountNumber" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label runat="server" AssociatedControlID="ddlFundingSource" CssClass="col control-label">Funding Source</asp:Label>
                            <div class="col">
                                <asp:DropDownList ID="ddlFundingSource" runat="server"
                                    CssClass="form-control">
                                    <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlFundingSource"
                                    CssClass="text-danger" ErrorMessage="Funding Source must be selected." />

                            </div>
                        </div>
                    </div>
                <!--  Ammount -->
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <div class="col-md-10">
                            <asp:Label runat="server" AssociatedControlID="txtPaymentAmount" CssClass="col control-label">Payment Amount </asp:Label>
                            <asp:TextBox runat="server" ID="txtPaymentAmount" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPaymentAmount"
                                ValidationGroup="AddPayeeForm"
                                CssClass="text-danger" ErrorMessage="Payment amount is required." />
                        </div>
                        <div class="col-md-2">
                            <asp:Label runat="server" AssociatedControlID="txtCurrency" CssClass="col control-label">Currency</asp:Label>
                            <asp:TextBox runat="server" ID="txtCurrency" CssClass="form-control" Text="USD" ReadOnly="true" />
                        </div>
                    </div>

                </div>
                <!-- Submit/Cancel BTN -->
                <div class="form-group col-md-12">
                    <div class="btn-group inline">
                        <!-- Hidden input -->
                        <asp:HiddenField runat="server" ID="hdnExistingUserPayeeId" Value="" />
                        <div class="col-md-offset-2">
                            <asp:Button runat="server" OnClick="CreatePayment_Click" Text="Make Payment" ValidationGroup="AddPayeeForm" CssClass="btn btn-primary mr-2" />
                        </div>
                        <div class="col-md-offset-2">
                            <asp:Button runat="server" OnClick="CancelPayment_Click" Text="Cancel" CssClass="btn btn-outline-danger mr-5" />
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
