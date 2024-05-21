<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Content/styles-admin.css" rel="stylesheet" />
    <img src="../img/honeyRogers.jpg" />
    <hr />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMINISTRADOR</h3>
    
    <hr />
    <p>Te encuentras en la zona de administrador.</p>
    <p>Haz click en los enlaces siguientes con objeto de efectuar las tareas asociadas.</p>
    <ul>
        <li> <a href="CategoryCreate.aspx">Crear nuevas categorías</a></li>
        <li><a href="CategoryList.aspx">Editar o eliminar categorías</a></li>
    </ul>
   
    
</asp:Content>
