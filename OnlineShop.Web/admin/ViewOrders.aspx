<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="OnlineShop.Web.admin.ViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />

    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <div class="header2">
        <div>
            <h4>LISTADO DE PEDIDOS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a><a href="Users.aspx">Ver pedidos por Usuario</a>
        </div>
    </div>
    <hr />
    <%-- Informo al admin como actuar con el grid view --%>
    <div class="text-center mb-4">
        <h3>Listado de ordenes de todos los clientes</h3>
        <p style="height: 10px; font-style: italic">* Pulsa en "Detalles" para ver el pedido detallado </p>
        <p style="height: 10px; font-style: italic">
            ** Pulsa en "Acción" para cambiar el estado del pedido
            (Pending -> InPreparation -> Shipping -> Delivered -> Cancelled)
        </p>

        <br />

        <!-- Dropdown para seleccionar estado -->
        <%-- El admin puede seleccionar todos los estados o uno en concreto --%>
        <p style="height: 10px; font-style: italic">
            Seleccione el estado de los pedidos:
        </p>
        <div>
            <div class="">
                <asp:DropDownList
                    ID="ddlOrderStatus"
                    runat="server"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged">
                    <asp:ListItem Text="Todos los estados" Value="" />
                    <asp:ListItem Text="Pending" Value="Pending" />
                    <asp:ListItem Text="In Preparation" Value="InPreparation" />
                    <asp:ListItem Text="Shipping" Value="Shipping" />
                    <asp:ListItem Text="Delivered" Value="Delivered" />
                    <asp:ListItem Text="Cancelled" Value="Cancelled" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="d-flex justify-content-center">
        <asp:Label ID="lblOrders" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
    <%-- AQUI SE MUESTRAS LOS PEDIOS DE LOS CLIENTES.
        SE MUESTRAS TODOS. SE ORDENAN POR FECHA, EL MÁS RECIENTE ARRIBA Y POR ESTADO DE LA ORDEN--%>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <%--Grid View para el listado de órdenes--%>
                <asp:GridView
                    OnRowCommand="gvOrderByUser_RowCommand"
                    ID="gvOrderByUser"
                    runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True"
                    PageSize="5"
                    CssClass="table table-bordered border-5 rounded"
                    RowStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-VerticalAlign="Middle"
                    BackColor="#99CCFF"
                    HeaderStyle-BackColor="Blue"
                    HeaderStyle-ForeColor="White"
                    ForeColor="White"
                    RowStyle-ForeColor="Black"
                    OnPageIndexChanging="gvOrderByUser_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Nº Pedido" />
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <%# GetUserEmail(Eval("User_Id")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DateOrder" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="OrderTotalPrice" HeaderText="Precio Total (€)" />
                        <asp:BoundField DataField="Status" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Detalles *">
                            <ItemTemplate>
                                <%-- Si el admin pulsa aqui, se muestra otro gridview con más detalles del pedido --%>
                                <asp:LinkButton ID="lnkDetails" runat="server" CommandName="Details" CommandArgument='<%# Eval("Id") %>' Text="Detalles"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acción **">
                            <ItemTemplate>
                                <%-- Si el admin pulsa aqui, se modificará el estado cada vez que pulse --%>
                                <asp:LinkButton ID="lnkChange" runat="server" CommandName="Change" CommandArgument='<%# Eval("Id") %>' Text="Modificar Estado"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <%-- Paginador --%>
                    <PagerTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton ID="lnkFirst" CommandName="Page" CommandArgument="First" runat="server" CssClass="btn btn-primary btn-sm m-2">Inicio</asp:LinkButton>
                            <asp:LinkButton ID="lnkPrev" CommandName="Page" CommandArgument="Prev" runat="server" CssClass="btn btn-primary btn-sm m-2">Anterior</asp:LinkButton>
                            <asp:LinkButton ID="lnkNext" CommandName="Page" CommandArgument="Next" runat="server" CssClass="btn btn-primary btn-sm m-2">Siguiente</asp:LinkButton>
                            <asp:LinkButton ID="lnkLast" CommandName="Page" CommandArgument="Last" runat="server" CssClass="btn btn-primary btn-sm m-2">Último</asp:LinkButton>
                        </div>
                        <div style="text-align: center">
                            <asp:Label ID="lblPager" CssClass="btn btn-secondary btn-sm m-2" runat="server" Text='<%# string.Format("Página {0} de {1}", gvOrderByUser.PageIndex + 1, gvOrderByUser.PageCount) %>'></asp:Label>
                        </div>
                    </PagerTemplate>
                </asp:GridView>
            </div>
            <div class="col-md-12">
                <%--Grid View para los detalles del pedido--%>
                <h4 class="text-center">Detalles del pedido</h4>
                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="gvOrderDetails_RowCommand"
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
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:LinkButton
                                    ID="lnkReturnProduct"
                                    runat="server"
                                    Text="Ir al Producto"
                                    CommandName="ReturnProduct"
                                    CommandArgument='<%# Eval("ProductName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
