<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="OnlineShop.Web.admin.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <h4>ACTUALIZAR PRODUCTO</h4>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" DisplayMode="List" />

    
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para el nombre del producto--%>
        <asp:Label ID="lblProduct"
            AssociatedControlID="txtProduct"
            runat="server"
            Text="Producto a actualizar"
            CssClass="col-md-3 fw-bold">
        </asp:Label>
        <asp:TextBox ID="txtProduct"
            runat="server"
            CssClass="col-md-3">
        </asp:TextBox>
    </div>
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para la descripción del producto--%>
        <asp:Label ID="lblDescription"
            AssociatedControlID="txtDescription"
            runat="server"
            Text="Descripción a actualizar"
            CssClass="col-md-3 fw-bold">
        </asp:Label>
        <asp:TextBox ID="txtDescription"
            runat="server"
            CssClass="col-md-3">
        </asp:TextBox>
    </div>
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para la categoría del producto--%>
        <asp:Label ID="Label3"
            AssociatedControlID=""
            runat="server"
            Text="Categoria a actualizar"
            CssClass="col-md-3 fw-bold">
        </asp:Label>
        <asp:DropDownList ID="ddlCategory"
            runat="server"
            CssClass="col-md-3">
        </asp:DropDownList>
    </div>
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para el precio del producto--%>
        <asp:Label ID="Label1"
            AssociatedControlID="txtPrice"
            runat="server"
            Text="Precio a actualizar"
            CssClass="col-md-3 fw-bold">
        </asp:Label>
        <asp:TextBox ID="txtPrice"
            runat="server"
            CssClass="col-md-3">
        </asp:TextBox>
    </div>
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para el stock del producto--%>
        <asp:Label ID="Label2"
            AssociatedControlID="txtStock"
            runat="server"
            Text="Stock a actualizar"
            CssClass="col-md-3 fw-bold">
        </asp:Label>
        <asp:TextBox ID="txtStock"
            runat="server"
            CssClass="col-md-3">
        </asp:TextBox>
    </div>
    <div class="row mb-3">
        <%--Etiqueta y campo de texto para la imagen del producto--%>
        <asp:Image ID="ProductImage" runat="server" Width="450" />
    </div>






</asp:Content>
