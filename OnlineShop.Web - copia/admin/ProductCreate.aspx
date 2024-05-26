<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="OnlineShop.Web.admin.ProductCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <div class="header2">
        <div>
            <h4>CREAR PRODUCTOS</h4>
        </div>
        <div>
                <a href="admin.aspx">Volver Inicio Administrador</a>
                <a href="ProductList.aspx">Ver Listado</a>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" DisplayMode="List" />
    <hr />
    <div class="row mb-3 ">
        <asp:Label ID="lblName" runat="server" Text="Nombre del producto" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="col-md-9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            runat="server" Display="Dynamic"
            ErrorMessage="El nombre es obligatorio"
            Text="El nombre es obligatorio"
            ControlToValidate="txtName">
        </asp:RequiredFieldValidator>
    </div>
    <div class="row mb-3 ">
        <asp:Label ID="lblDescription" runat="server" Text="Descripción del producto" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="col-md-9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
            runat="server" Display="Dynamic"
            ErrorMessage="La descripción es obligatoria"
            Text="La descripción es obligatoria"
            ControlToValidate="txtDescription">
        </asp:RequiredFieldValidator>

    </div>

    <div class="row mb-3  ">
        <asp:Label ID="lblStock" runat="server" Text="Stock Actual" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="col-md-9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
            runat="server"
            ErrorMessage="El stock es obligatorio"
            Text="El stock es obligatorio"
            ControlToValidate="txtDescription" Display="Dynamic">
        </asp:RequiredFieldValidator>
    </div>

    <div class="row mb-3">
        <asp:Label ID="lblCategoria" runat="server" Text="Categoría" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="col-md-3"></asp:DropDownList>
    </div>

    <div class="row mb-3 ">
        <asp:Label ID="lblPrice" runat="server" Text="Precio Actual (€)" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" CssClass="col-md-9"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
            runat="server" Display="Dynamic"
            ErrorMessage="El precio es obligatorio"
            Text="El precio es obligatorio"
            ControlToValidate="txtPrice">
        </asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Precio fuera de rango" Display="Dynamic" ControlToValidate="txtPrice" MaximumValue="50" MinimumValue="0" Text="Precio fuera de rango"></asp:RangeValidator>
    </div>

    <div class="row mb-3">
        <asp:Label ID="lblPhoto" runat="server" Text="Sube una foto" CssClass="col-md-3 fw-bold"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="col-md-3"></asp:FileUpload>
        <asp:Button ID="btnUpload" runat="server" Text="Subir Archivo" CssClass="col-md-3" OnClick="btnUpload_Click" />
        <asp:Label ID="UpLoadOK" runat="server" Text="" CssClass="col-md-3"></asp:Label>
    </div>

    <div class="row mb-3 mt-4">
        <asp:Button ID="BtnSubmit" CssClass="offset-3 col-md-4 btn btn-primary" runat="server" Text="Crear Producto" OnClick="BtnSubmit_Click" />
    </div>
    <hr />
    <h4>LISTADO DE PRODUCTOS</h4>
    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" CssClass="mb-2">
        <asp:ListItem Text="5" Value="5" Selected="True"></asp:ListItem>
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="50" Value="50"></asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvProducts_PageIndexChanging" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:BoundField DataField="Description" HeaderText="Descripción" />
            <asp:BoundField DataField="Price" HeaderText="Precio" DataFormatString="{0:n} €" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="CategoryName" HeaderText="Categoría" />
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <%--<asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />--%>
                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FirstImagePath") %>' Height="70" />
                </ItemTemplate>
            </asp:TemplateField>
  
        </Columns>
    </asp:GridView>

    <asp:DataList ID="dlProducts" runat="server" CssClass="table table-striped" RepeatColumns="2" CellPadding="5">
        <ItemTemplate>
            <div class="text-center">
                <h4>Nombre: <%# Eval("Name") %></h4>
                <p>Descripción: <%# Eval("Description") %></p>
                <p>Precio: <%# Eval("Price", "{0:n} €") %></p>
                <p>Stock: <%# Eval("Stock") %></p>
                <p>Categoría: <%# Eval("Category.CategoryName") %></p>
                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />
            </div>
        </ItemTemplate>
    </asp:DataList>

    <ul>
        <li><a href="admin.aspx">Volver Inicio Admin</a></li>
        <li><a href="#">Ver listado de productos</a></li>

    </ul>














</asp:Content>
