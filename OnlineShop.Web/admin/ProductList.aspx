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
        CssClass="table table-bordered border-5 rounded"
        AllowPaging="True"
        PageSize="5"
        OnPageIndexChanging="gvProducts_PageIndexChanging"
        BackColor="#99CCFF"
        HeaderStyle-BackColor="Blue"
        HeaderStyle-ForeColor="White"
        AllowSorting="True"
        RowStyle-HorizontalAlign="Center"
        HeaderStyle-HorizontalAlign="Center"
        HeaderStyle-VerticalAlign="Middle"
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
        <PagerTemplate>
    <div style="text-align: center">
        <asp:LinkButton ID="lnkFirst" CommandName="Page" CommandArgument="First" runat="server" CssClass="btn btn-primary btn-sm m-2">Inicio</asp:LinkButton>
        <asp:LinkButton ID="lnkPrev" CommandName="Page" CommandArgument="Prev" runat="server" CssClass="btn btn-primary btn-sm m-2">Anterior</asp:LinkButton>
        <asp:LinkButton ID="lnkNext" CommandName="Page" CommandArgument="Next" runat="server" CssClass="btn btn-primary btn-sm m-2">Siguiente</asp:LinkButton>
        <asp:LinkButton ID="lnkLast" CommandName="Page" CommandArgument="Last" runat="server" CssClass="btn btn-primary btn-sm m-2">Último</asp:LinkButton>
    </div>
    <div style="text-align: center">
        <asp:Label ID="lblPager" CssClass="btn btn-secondary btn-sm m-2" runat="server" Text='<%# string.Format("Página {0} de {1}", gvProducts.PageIndex + 1, gvProducts.PageCount) %>'></asp:Label>
    </div>

</PagerTemplate>
    </asp:GridView>




</asp:Content>
