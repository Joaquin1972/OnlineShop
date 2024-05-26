<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OnlineShop.Web.admin.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <%--<link href="../Content/tableList.css" rel="stylesheet" />--%>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">--%>
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <div class="header2">
        <div>
            <h4>LISTADO DE PRODUCTOS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="ProductCreate.aspx">Volver a Crear Productos</a>
        </div>
    </div>
    <hr />


    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" CssClass="mb-2">
        <asp:ListItem Text="5" Value="5" Selected="True"></asp:ListItem>
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="50" Value="50"></asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="gvProducts" 
        runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-striped"
        AllowPaging="True" 
        PageSize="5" 
        OnPageIndexChanging="gvProducts_PageIndexChanging" 
        AllowSorting="True"
        OnSelectedIndexChanging="gvProducts_SelectedIndexChanging" 
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:BoundField DataField="Description" HeaderText="Descripción" />
            <asp:BoundField DataField="Price" HeaderText="Precio" DataFormatString="{0:n} €" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="CategoryName" HeaderText="Categoría" />
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FirstImagePath") %>' Height="70" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkSelect" runat="server" Text="Seleccionar" CommandName="Select" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>




</asp:Content>
