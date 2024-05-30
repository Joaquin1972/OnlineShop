<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentGateway.aspx.cs" Inherits="OnlineShop.Web.client.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pasarela de Pago</h2>
    <asp:Label ID="lblPaymentAmount" runat="server" Text="Label"></asp:Label>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Nº Tarjeta"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Fecha de caducidad"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="CCV"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</asp:Content>
