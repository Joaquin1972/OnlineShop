<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentShoppingCart.aspx.cs" Inherits="OnlineShop.Web.client.CurrentShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h2>Hola, <%: Context.User.Identity.GetUserName() %>!</h2>
        <h4>Aquí tienes tu cesta de la compra actual<br />
            Pulsa en <b>"Realizar pedido"</b> para entrar en la pasarela de pago
        </h4>
    </div>
    Identificador de pedido: <asp:Label ID="LblOrderUserIdPending" runat="server" Text=""></asp:Label><br />
    Fecha de pedido: <asp:Label ID="LblDateOrderUserIdPending" runat="server" Text=""></asp:Label>


   <%-- <asp:GridView ID="gvUserOrders" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID del Pedido" />
            <asp:BoundField DataField="DateOrder" HeaderText="Fecha del Pedido" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Status" HeaderText="Estado del Pedido" />
        </Columns>
    </asp:GridView>--%>
</asp:Content>

