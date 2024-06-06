<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserArea.aspx.cs" Inherits="OnlineShop.Web.client.UserArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center mb-4">
        <h3>Hola, <%: Context.User.Identity.GetUserName()  %>, estás en tu área personal.<br />
            Aquí puedes consultar el histórico de pedidos.
        </h3>
    </div>



    <div class="container">
        <div class="row">
            <div class="col-md-6">
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
            <div class="col-md-6">
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



<%--    <div>
        <h3>Estos son tus datos personales</h3>
        <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
        <asp:Label ID="LblAdress" runat="server" Text=""></asp:Label>
        <asp:Label ID="LblCP" runat="server" Text=""></asp:Label>
        <asp:Label ID="LblCity" runat="server" Text=""></asp:Label>
        <asp:Label ID="LblCountry" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnUpdate" runat="server" Text="Ir a actualizar datos personales" CssClass="btn btn-primary" OnClick="btnUpdatePersonalData_Click" />
    </div>--%>

    
        <div class="container mt-5">
            <div class="card col-4">
                <div class="card-header bg-primary text-white">
                    <h3 class="card-title">Estos son tus datos personales</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="LblName">Nombre:</label>
                        <asp:Label ID="LblName" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="LblAddress">Dirección:</label>
                        <asp:Label ID="LblAdress" runat="server"  />
                    </div>
                    <div class="form-group">
                        <label for="LblCP">Código Postal:</label>
                        <asp:Label ID="LblCP" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="LblCity" class="fw-bold">Ciudad:</label>
                        <asp:Label ID="LblCity" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="LblCountry">País:</label>
                        <asp:Label ID="LblCountry" runat="server" />
                    </div>
                    <asp:Button ID="btnUpdate" runat="server" Text="Ir a actualizar datos personales" CssClass="btn btn-primary mt-3" OnClick="btnUpdatePersonalData_Click" />
                </div>
            </div>
        </div>
  






</asp:Content>
