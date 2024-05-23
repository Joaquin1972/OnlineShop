<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OnlineShop.Web.admin.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />

    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <h4>LISTADO DE PRODUCTOS</h4>
    <br />
    <table id="products" class="table table-bordered table-striped justify-content-center">
        <thead>
            <tr>
                <th>NOMBRE</th>
                <th>DESCRIPCION</th>
                <th>PRECIO</th>
                <th>STOCK</th>
                <th>CATEGORIA</th>

            </tr>
        </thead>

        <tbody>
            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Description") %></td>
                        <td><%# Eval("Price", "{0:C}") %></td>
                        <td><%# Eval("Stock") %></td>
                        <td>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>


    </table>

    <hr />

    <ul>
        <li><a href="ProductCreate.aspx">Crear nuevo producto</a></li>
        <li><a href="admin.aspx">Volver Inicio Admin</a></li>

    </ul>



</asp:Content>
