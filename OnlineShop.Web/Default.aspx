<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineShop.Web._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>

        

        img {
            display: block;
            margin: 0 auto;
            width: 100%;
            height: auto;
            border: 1px solid black;
            border-radius: 50%;
            box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
            transition: 0.5s;
        }

            img:hover {
                transform: scale(1.1);
            }
        /*        .img_ini {
            display: flex;
            flex-direction: row;
            justify-content: space-evenly;
            margin: 10px 0px 10px 0px;
        }*/
    </style>
    <link href="Content/default.css" rel="stylesheet" />
    <main class="main-gradient">
        <div class="justify-content-center col-md-12">
            <h1 class="bg-primary text-white p-1  rounded-4 text-center shadow">BIENVENIDO A NORABEL PLAY</h1>
            <h2 style="text-align: center; margin-bottom: 20px;">Tu tienda online más completa del universo Playmobil</h2>
        </div>
        <div class="container">
            <div class="row">
               
                <div class="col-12 col-md-12 img_ini">
                    <img src="img/honeyRogers.jpg" class="img-fluid">
                    <img src="img/pirata2.jpg" class="img-fluid">
                    <img src="img/honeyRogers.jpg" class="img-fluid">
                    <img src="img/pirata2.jpg" class="img-fluid">
                    <img src="img/honeyRogers.jpg" class="img-fluid">
                </div>
            </div>
        </div>



        <section class="row mt-3" aria-labelledby="aspnetTitle">


            <p class="lead">
                ¡Bienvenido a nuestra tienda online <b>Norabel Play</b>! Descubre nuestro extenso y fascinante stock de Playmobiles, 
                perfecto para despertar la imaginación y la aventura en cada rincón de tu hogar. 
                ¡Explora y encuentra tu playmobil favorito hoy mismo!
            </p>
            <p class="lead">
                En <b>Norabel Play</b>
            , sabemos la importancia de inspirar a los niños a soñar y explorar. 
                Nuestras colecciones incluyen emocionantes aventuras de piratas, perfectas para épicas búsquedas de tesoros 
                y enfrentamientos en altamar. 
         <p class="lead">
             Para los amantes del salvaje oeste, ofrecemos duelos de vaqueros y defensa contra bandidos. 
                Sumérgete en mundos mágicos con hadas y castillos encantados. 
                También tenemos sets urbanos de bomberos, policías y hospitales para vivir emocionantes historias de ciudad.
         </p>
            <p class="lead">
                ¡Navega cual barco pirata por nuestra tienda online <b>Norabel Play</b> y sumergete en un mundo de aventuras sin límite!
            </p>
            <p><a href="client/tienda.aspx" class="btn btn-primary btn-md">Quiero entrar &raquo;</a></p>
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
