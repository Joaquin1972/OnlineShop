<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineShop.Web._Default" %>
    

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/default.css" rel="stylesheet" />
    <main>
        <h1 style="text-align: center;">BIENVENIDO A LA TIENDA PIRATA</h1>
        <div class="img_ini">
        <img src="img/honeyRogers.jpg">
            <img src="img/honeyRogers.jpg">
            <img src="img/honeyRogers.jpg">
            <img src="img/honeyRogers.jpg">
            <img src="img/honeyRogers.jpg">

        </div>
        <section class="row" aria-labelledby="aspnetTitle">


            <p class="lead">
                ¡Bienvenido a <b>La Tienda Pirata</b>! Descubre nuestro extenso y fascinante stock de Playmobiles, 
                perfecto para despertar la imaginación y la aventura en cada rincón de tu hogar. 
                ¡Explora y encuentra tu playmobil favorito hoy mismo!
            </p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
