<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="OnlineShop.Web.admin.ViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center mb-4">
        <h3>Listado de ordenes de todos los clientes
        </h3>
    </div>



    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4 class="text-center">Listado de pedidos</h4>
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
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <%# GetUserEmail(Eval("User_Id")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DateOrder" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="OrderTotalPrice" HeaderText="Precio Total (€)" />
                        <asp:BoundField DataField="Status" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Detalles">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetails" runat="server" CommandName="Details" CommandArgument='<%# Eval("Id") %>' Text="Detalles"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalles">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkChange" runat="server" CommandName="Change" CommandArgument='<%# Eval("Id") %>' Text="Modificar Estado"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-12">
                <h4 class="text-center">Detalles del pedido</h4>
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

</asp:Content>
