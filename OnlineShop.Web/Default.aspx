<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineShop.Web._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>

    </style>
   <link href="Content/default.css" rel="stylesheet" />
    <main class="main-gradient">
        <div class="justify-content-center col-md-12">
            <%--<h1 class="bg-primary text-white p-1  rounded-4 text-center shadow">BIENVENIDO A NORABEL PLAY</h1>--%>
            <h2 style="text-align: center; margin-bottom: 20px;">Estás en la tienda online más completa del universo Playmobil</h2>
        </div>
        <div class="container">
            <div class="row">
                <div class="img_ini">
                    <img src="img/honeyRogers.jpg" class="img_face face1">
                    <img src="img/pirata2.jpg" class="img_face face2">
                    <img src="img/hadajimena.jpg" class="img_face face2">
                    <img src="img/sheriff.jpg" class="img_face face2">
                    <img src="img/policia.jpg" class="img_face face2">
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
                Nuestro stock incluye los más valientes piratas en busca de remotas islas del tesora.
         <p class="lead">
             Para los amantes del salvaje oeste, tenemos una repleta colección de indios y vaqueros. 
             Si quieres vivir el día a día de la ciudad, tenemos bomberos, policías, escuelas infantiles, ...
         </p>
            <p class="lead">
                ¡Navega cual barco pirata por nuestra tienda online <b>Norabel Play</b> y sumergete en un mundo de aventuras sin límite!
            </p>
            <p><a href="client/tienda.aspx" class="btn btn-primary btn-md">Quiero entrar &raquo;</a></p>
        </section>
        <div class="img_down">
            <img src="img/barco.jpg" class="img_2" />
            <img src="img/escuela.jpg" class="img_2" />
            <img src="img/indios.jpg" class="img_2" />
        </div>
    </main>

</asp:Content>
