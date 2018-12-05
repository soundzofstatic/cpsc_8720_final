<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineBillPay._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- ***** Wellcome Area Start ***** -->
    <section class="wellcome_area clearfix" id="home">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12 col-md">
                    <div class="wellcome-heading">
                        <h2>OnlineBillPay</h2>
                        <p>The last Online bill payment system you will ever use. Period.</p>
                    </div>
                    <div class="get-start-area">
                    </div>
                </div>
            </div>
        </div>
        <!-- Welcome thumb -->
        <div class="welcome-thumb wow fadeInDown" data-wow-delay="0.5s">
            <img src="img/bg-img/welcome-img.png" alt="">
        </div>
    </section>
    <!-- ***** Wellcome Area End ***** -->
    <main id="nested" class="container mt-5">
        <div class="row white-bg">
            <div class="col-md-12">
                <div class="form-horizontal">
                    <div id="errorAlerts" class="alert alert-danger" role="alert" runat="server" visible="false">
                        <p runat="server" id="pNotification1" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row white-bg">
            <div class="col-md-8">
                <h2>Getting started</h2>
                <p><strong>The first and last bill payment system you will ever use!</strong> Features include: </p>
                <ul>
                    <li>- Easily Set up unlimited number of payees</li>
                    <li>- Search for well-known payees</li>
                    <li>- Set up multiple funding sources</li>
                </ul>
            </div>
            <div class="col-md-4">
                <h2>Always Free!</h2>
                <p>Bill payment system is now and will always free! <strong>Join Today!</strong></p>
                <a href="/Account/Register" title="Join OnlineBillPay" class="btn btn-warning">Join Today!</a>

            </div>
        </div>
    </main>

</asp:Content>
