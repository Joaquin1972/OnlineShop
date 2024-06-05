<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="OnlineShop.Web.admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <div class="header2">
        <div>
            <h4>LISTADO DE USUARIOS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="ViewOrders.aspx">Ver pedidos por Status</a>
        </div>
    </div>
    <hr />
    <div class="container d-flex justify-content-center">
        <div class="col-12 col-md-6">
            <%-- Grid View para el listado de usuarios --%>
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered border-5 rounded"
    RowStyle-HorizontalAlign="Center"
    HeaderStyle-HorizontalAlign="Center"
    HeaderStyle-VerticalAlign="Middle"
    BackColor="#99CCFF"
    HeaderStyle-BackColor="Blue"
    HeaderStyle-ForeColor="White"
    ForeColor="White"
    RowStyle-ForeColor="Black">
    <Columns>
        <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
        <asp:BoundField DataField="UserName" HeaderText="Nombre de Usuario" />
        <asp:TemplateField HeaderText="Ver Pedidos">
            <ItemTemplate>
                <asp:HyperLink 
                    ID="hlDetails" 
                    runat="server" 
                    NavigateUrl='<%# "UserArea.aspx?id=" + Eval("ID") %>' 
                    Text="Ver Pedidos" 
                    ForeColor="White"
                    CssClass="btn btn-primary btn-sm">
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
    </div>
</asp:Content>
