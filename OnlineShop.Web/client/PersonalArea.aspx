<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalArea.aspx.cs" Inherits="OnlineShop.Web.client.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Hola, <%: Context.User.Identity.GetUserName()  %>, estás en tu área personal.</h3>
    <p class="lead">Aquí puedes comprobar tus últimos pedidos</p>
</asp:Content>
