<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEditClient.aspx.cs" Inherits="OnlineShop.Web.client.ProductEditClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" rel="stylesheet">


    <style>
        .imgClient {
            display: block;
            margin: 20px auto 20px auto;
            width: 25%;
            border: 2px solid white;
            border-radius: 5px;
            box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        }
    </style>
    <div class="justify-content-center col-md-12">

        <h2 class="text-center mt-3 mb-3">
            <asp:Label ID="Label1" runat="server" Text="Te presentamos a ... "></asp:Label>
            <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
        </h2>
        <asp:Image ID="ProductImage" runat="server" CssClass="imgClient" />

        <h4 class="text-center">
            <asp:Label ID="LblDescription" runat="server" Text="Label"></asp:Label>
        </h4>
        <h4 class="text-center">
            <asp:Label ID="LblPrice" runat="server" Text="Label"></asp:Label>
        </h4>
        <div class="row justify-content-center mt-2">
            Cantidad: 
            <div class="col-auto">
                <asp:DropDownList ID="DdlStock" runat="server" CssClass=""></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="container mt-3">
        <div class="row justify-content-center">
            <div class="col-auto text-center">

                <asp:Button ID="BtnSell" runat="server" Text="¡Lo quiero comprar!" CssClass="btn btn-dark mb-3" Enabled="true" OnClick="BtnSell_Click" />
                <asp:Button ID="Return" runat="server" Text="Volver al listado" CssClass="btn btn-primary mb-3" OnClick="Return_Click" />
            </div>
        </div>

    </div>
    <div class="row justify-content-center">
        <div class="text-center  col-md-4 col-12 mt-3 mb-3">
            <asp:Label ID="lblAlert" runat="server" CssClass="text-center" Text=""></asp:Label>
        </div>
    </div>





</asp:Content>
