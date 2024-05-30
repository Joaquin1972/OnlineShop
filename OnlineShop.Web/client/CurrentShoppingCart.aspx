<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentShoppingCart.aspx.cs" Inherits="OnlineShop.Web.client.CurrentShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .common-style {
            /*border: 1px solid blue;*/
            border-radius: 5px;
            background-color: rgba(255, 255, 255, 0.3); /* Transparencia del 30% */
        }

        .order {
            padding: 10px;
            list-style: none;
            line-height: 30px;
        }

        .buttons {
            display: flex;
            justify-content: space-around;
            padding: 10px;
            margin: 5px auto 5px auto;
            border-radius: 5px;
        }
    </style>
    <%-- Si el codebehind ha rellenado el GridView significa que hay productos en la cesta, 
        por lo que se renderizar este codigo --%>
    <% if (gvUserOrders.Rows.Count > 0)
        { %>


    <div class="text-center ">
        <h2>Hola, <%: Context.User.Identity.GetUserName() %>!</h2>
        <ul class="order">
            <li>Aquí tienes tu cesta de la compra actual</li>
            <li>Pulsa en <b>"Realizar pedido"</b> para entrar en la pasarela de pago</li>
            <li>Pulsa en <b>"Quiero seguir comprando"</b> para volver a la tienda.</li>
        </ul>
    </div>
    <hr />

    <%-- Creo el detalle del pedido --%>
    <div class="container mt-5">
        <div class="row col-md-12">
            <%-- Columna izda: Resumen del pedido, con fecha y cantidad total --%>
            <div class="col-md-4">
                <h3 class="text-center">Resumen del pedido</h3>
                <ul class="order common-style">
                    <li>Número de pedido:
            <asp:Label ID="LblOrderUserIdPending" runat="server" Text=""></asp:Label>
                    </li>
                    <li>Fecha de pedido:
            <asp:Label ID="LblDateOrderUserIdPending" runat="server" Text=""></asp:Label>
                    </li>
                    <li class="text-center fw-bold">
                        <h4>Precio total:
            <asp:Label ID="LblTotalOrderPrice" runat="server" Text=""></asp:Label></h4>
                    </li>
                </ul>
                <div class="buttons common-style">
                     <asp:Button ID="MakePayment" runat="server" Text="Realizar Pedido" CssClass="btn btn-success" OnClick="BtnMakePayment_Click" />
                    <button type="button" class="btn btn-primary">Quiero seguir comprando</button>
                </div>
            </div>
            <%-- Columna derecha, el detalle del pedido con todos los productos --%>
            <div class="col-md-8">
                <h3 class="text-center">Detalle del pedido</h3>
                <%--<asp:GridView ID="gvUserOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUserOrders_RowCommand" CssClass="table table-striped common-style" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                   <Columns>
                        <asp:BoundField DataField="Quantity" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ProductName" HeaderText="Nombre del producto" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Precio Unitario (€)" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Total (€)" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>--%>
                <asp:GridView ID="gvUserOrders" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUserOrders_RowCommand" CssClass="table table-striped common-style" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Quantity" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ProductName" HeaderText="Nombre del producto" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Precio Unitario (€)" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Total (€)" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%-- Botón para retornar al producto --%>
                                <asp:LinkButton ID="btnReturnProduct" runat="server" CommandName="ReturnProduct" CommandArgument='<%# Eval("Productname") %>' cssclass="btn btn-secondary" Text="Ir al producto" />
                                <%-- Botón para borrar el producto de la lista de la compra --%>
                                <asp:LinkButton ID="btnDeleteItem" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("Id") %>' cssclass="btn btn-danger" Text="Borrar" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>

    <%--    <div class="buttons common-style">
        <button type="button" class="btn btn-success">Realizar Pedido</button>
        <button type="button" class="btn btn-primary">Quiero seguir comprando</button>
    </div>--%>

    <% }

        else

        { %>
    <%-- Si no hay productos en la cesta, se renderiza simplemente esto --%>
    <div class="text-center">
        <h2>Hola, <%: Context.User.Identity.GetUserName() %>!</h2>
        <h3>No tienes órdenes pendientes.</h3>
    </div>
    <% } %>
</asp:Content>

