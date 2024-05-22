<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OnlineShop.Web.admin.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <link href="//cdn.datatables.net/2.0.7/css/dataTables.dataTables.min.css" rel="stylesheet" />

    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <h4>LISTADO DE PRODUCTOS</h4>
    <table class="table table-bordered text-center">
        <tr class="">
            <th>NOMBRE</th>
            <th>DESCRIPCION</th>
            <th>PRECIO</th>
            <th>STOCK</th>
            <th>CATEGORIA</th>
            <th>IMAGEN</th>
        </tr>
        <tr>
            <td>x</td>
            <td>x</td>
            <td>x</td>
            <td>x</td>
            <td>x</td>
            <td>x</td>


        </tr>



    </table>
    <ul>
        <li><a href="ProductCreate.aspx">Crear nuevo producto</a></li>
        <li><a href="admin.aspx">Volver Inicio Admin</a></li>

    </ul>
    
    
     <script src="https://cdn.datatables.net/2.0.7/js/dataTables.min.js"></script>
</asp:Content>
