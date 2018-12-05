<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OnlineBillPay.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="wellcome_area regular_hero clearfix" id="about">
            <div class="container h-100">
                <div class="row h-100 align-items-center">
                    <div class="col-12 col-md">
                        <div class="wellcome-heading">
                            <h2><%: Title %>.</h2>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Welcome thumb -->
            <div class="welcome-thumb wow fadeInDown" data-wow-delay="0.5s">
                <img src="img/bg-img/welcome-img.png" alt="">
            </div>
        </section>
</asp:Content>
