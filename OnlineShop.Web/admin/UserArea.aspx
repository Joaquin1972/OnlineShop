<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserArea.aspx.cs" Inherits="OnlineShop.Web.Admin.UserArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <div class="header2">
        <div>
            <h4>PEDIDOS POR USUARIO</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="Users.aspx">Volver a Usuarios Registrados</a>
            <a href="ViewOrders.aspx">Ir a Pedidos por Status</a>
        </div>
    </div>
    <hr />

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h4 class="text-center mb-4">
                    <asp:Label ID="OrdersUser" runat="server" Text=""></asp:Label>
                </h4>
                <%-- Pedidos --%>
                <asp:GridView
                    OnRowCommand="gvOrderByUser_RowCommand"
                    ID="gvOrderByUser"
                    runat="server"
                    AutoGenerateColumns="False"
                    AllowCustomPaging="True" AllowPaging="True"
                    CssClass="table table-bordered border-5 rounded"
                    RowStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-VerticalAlign="Middle"
                    BackColor="#99CCFF"
                    HeaderStyle-BackColor="Blue"
                    HeaderStyle-ForeColor="White"
                    ForeColor="White" RowStyle-ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Nº Pedido" />
                        <asp:BoundField DataField="DateOrder" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="OrderTotalPrice" HeaderText="Precio Total (€)" />
                        <asp:BoundField DataField="Status" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Detalles">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetails" runat="server" CommandName="Details" CommandArgument='<%# Eval("Id") %>' Text="View Details"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <%-- Detalles del pedido --%>
            <div class="col-md-6">
                <h4 class="text-center mb-4">Detalles del pedido</h4>
                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False"
                    AllowCustomPaging="True" AllowPaging="True"
                    CssClass="table table-bordered border-5 rounded"
                    RowStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-VerticalAlign="Middle"
                    BackColor="#99CCFF"
                    HeaderStyle-BackColor="Blue"
                    HeaderStyle-ForeColor="White"
                    ForeColor="White" RowStyle-ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="OrderId" HeaderText="Nº Pedido" />
                        <asp:BoundField DataField="ProductName" HeaderText="Producto" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Precio Unitario (€)" />
                        <asp:BoundField DataField="Quantity" HeaderText="Cantidad" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Precio Total (€)" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <%-- Datos personales --%>
    <div class="container mt-5">
        <div class="card col-4">
            <div class="card-header bg-primary text-white">
                <h3 class="card-title">Estos son sus datos personales</h3>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="LblName" class="fw-bold">Nombre:</label>
                    <asp:Label ID="LblName" runat="server" />
                </div>
                <div class="form-group">
                    <label for="LblAddress" class="fw-bold">Dirección:</label>
                    <asp:Label ID="LblAdress" runat="server" />
                </div>
                <div class="form-group">
                    <label for="LblCP" class="fw-bold">Código Postal:</label>
                    <asp:Label ID="LblCP" runat="server" />
                </div>
                <div class="form-group">
                    <label for="LblCity" class="fw-bold">Ciudad:</label>
                    <asp:Label ID="LblCity" runat="server" />
                </div>
                <div class="form-group">
                    <label for="LblCountry" class="fw-bold">País:</label>
                    <asp:Label ID="LblCountry" runat="server" />
                </div>

            </div>
        </div>
    </div>



</asp:Content>
