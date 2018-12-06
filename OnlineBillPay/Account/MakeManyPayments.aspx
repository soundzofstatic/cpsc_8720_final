<%@ Page Title="Manage Payees" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="MakeManyPayments.aspx.cs" Inherits="OnlineBillPay.Account.MakeManyPayments" %>

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
                    <h2>Payees</h2>
                    <asp:Repeater ID="PayeeList" runat="server">
                        <HeaderTemplate>
                            <div class="payee-group row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-md-6 mb-3 pr-3">
                                <div class="card">
                                    <div class="card-body">
                                        <h3 class="card-title"><%# Eval("Nickname") %></h3>
                                        <div class="form-row mb-2">
                                            <asp:DropDownList runat="server" ID="ddlFundingSource" OnDataBinding="ddlFundingSource_DataBinding" CssClass="form-control">
                                                <asp:ListItem Text="Select Funding Source" Value="" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlFundingSource"
                                                CssClass="text-danger" ErrorMessage="Funding Source must be selected." />
                                        </div>
                                        <div class="form-row">
                                            <div class="form-group col-md-8">
                                                <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" placeholder="Amount" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAmount"
                                                    CssClass="text-danger" ErrorMessage="Payment amount is required." />
                                            </div>
                                            <div class="form-group col-md-4">
                                                <asp:TextBox runat="server" ID="txtCurrency" CssClass="form-control" Value="USD" Text="USD" ReadOnly="true" />
                                            </div>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hdnField" Value='<%# Eval("UserPayeeId") %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="SubmitMassPayee_Click" Text="Submit Payments" CssClass="btn btn-default" />
                        </div>
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
