<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .menuAdmin li {
            list-style: none;
            background-color: black;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 2px 2px 2px gray;
            transition: 0.5s;
            margin-top: 5px;
        }

            .menuAdmin li:hover {
                background-color: darkgray;
            }

            .menuAdmin li a {
                color: white;
                text-decoration: none;
            }
    </style>
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <img src="../img/honeyRogers.jpg" width="60" id="image_init" />

    <hr />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMINISTRADOR</h3>

    <hr />
    <p>Te encuentras en la zona de administrador.</p>
    <p>Haz click en los enlaces siguientes con objeto de efectuar las tareas asociadas.</p>
    <div class="row justify-content-center text-center">
        <div class="col-12 col-md-4">
            <ul class="menuAdmin">
                <li class="p-2"><a href="CategoryCreate.aspx">Crear nuevas categorías</a></li>
                <li class="p-2"><a href="CategoryList.aspx">Editar o eliminar categorías</a></li>
                <li class="p-2"><a href="ProductCreate.aspx">Crear Productos</a></li>
                <li class="p-2"><a href="ProductList.aspx">Listar Productos</a></li>
                <li class="p-2"><a href="ViewOrders.aspx">Ver Pedidos</a></li>
            </ul>
        </div>
    </div>

</asp:Content>
