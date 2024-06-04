<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineShop.Web._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .img_face {
            display: block;
            margin: 0 auto;
            width: 12%;
            border: 1px solid black;
            border-radius: 50%;
            box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
            transition: 0.5s;
        }

            .img_face:hover {
                transform: scale(1.1);
            }

        .img_ini {
            display: flex;
            flex-direction: row;
            justify-content: space-evenly;
            margin: 10px 0px 10px 0px;
        }

        .img_2 {
            display: flex;
            justify-content: center;
            width: 100%;
            height: auto;
            border: 1px solid black;
            box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
        }

        .img-container {
            width: 300px; /* Ajusta el ancho según tus necesidades */
            height: 200px; /* Ajusta la altura según tus necesidades */
            overflow: hidden;
        }

            .img-container img {
                width: 100%;
                height: 100%;
                object-fit: cover; /* Asegura que la imagen cubra todo el contenedor */
            }
    </style>
    <%--<link href="Content/default.css" rel="stylesheet" />--%>
    <main class="main-gradient">
        <div class="justify-content-center col-md-12">
            <%--<h1 class="bg-primary text-white p-1  rounded-4 text-center shadow">BIENVENIDO A NORABEL PLAY</h1>--%>
            <h2 style="text-align: center; margin-bottom: 20px;">Estás en la tienda online más completa del universo Playmobil</h2>
        </div>
        <div class="container">
            <div class="row">

                <div class="img_ini">
                    <img src="img/honeyRogers.jpg" class="img_face">
                    <img src="img/pirata2.jpg" class="img_face">
                    <img src="img/hadajimena.jpg" class="img_face">
                    <img src="img/sheriff.jpg" class="img_face">
                    <img src="img/policia.jpg" class="img_face">
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

        <%--<div class="row">
            <section class="col-md-4 justify-content-center" aria-labelledby="gettingStartedTitle">
                <div class="img-container">
                    <img src="img/barco.jpg" class="img_2" />
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <div class="img-container">
                    <img src="img/escuela.jpg" class="img_2" />
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <div class="img-container">
                    <img src="img/indios.jpg" class="img_2" />
                </div>
            </section>
        </div>--%>
    </main>

</asp:Content>
