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
                                            <asp:DropDownList runat="server" ID="ddlFundingSource" CssClass="form-control">
                                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-row">
                                            <asp:TextBox runat="server" ID="txtAccount" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
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
