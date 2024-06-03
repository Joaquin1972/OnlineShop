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
   <div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8 col-12">
            <div class="row mb-3 mt-3">
                <asp:Label ID="lblName" runat="server" Text="Nombre" CssClass="col-md-3 fw-bold"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="col-md-9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" Display="Dynamic"
                    ErrorMessage="El nombre es obligatorio"
                    Text="El nombre es obligatorio"
                    ControlToValidate="txtName">
                </asp:RequiredFieldValidator>
            </div>
            <div class="row mb-3 mt-3">
                <asp:Label ID="lblDescription" runat="server" Text="Descripción" CssClass="col-md-3 fw-bold"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="col-md-9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" Display="Dynamic"
                    ErrorMessage="La descripción es obligatoria"
                    Text="La descripción es obligatoria"
                    ControlToValidate="txtDescription">
                </asp:RequiredFieldValidator>
            </div>
            <div class="row mb-3 mt-3">
                <asp:Label ID="lblStock" runat="server" Text="Stock Actual" CssClass="col-md-3 fw-bold"></asp:Label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="col-md-9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server"
                    ErrorMessage="El stock es obligatorio"
                    Text="El stock es obligatorio"
                    ControlToValidate="txtStock" Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="row mb-3 mt-3">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría" CssClass="col-md-3 fw-bold"></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="col-md-4"></asp:DropDownList>
            </div>
            <div class="row mb-3 mt-3">
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
            <div class="row mb-3 mt-3">
                <asp:Label ID="lblPhoto" runat="server" Text="Sube una foto" CssClass="col-md-3 fw-bold"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="col-md-9"></asp:FileUpload>
            </div>
            <div class="row mb-3 mt-4 offset-4">
                <asp:Button ID="btnUpload" runat="server" Text="Subir Archivo" CssClass="col-md-3" OnClick="btnUpload_Click" />
                <asp:Label ID="UpLoadOK" runat="server" Text="" CssClass="col-md-9"></asp:Label>
            </div>
            <div class="row mb-3 mt-4">
                <asp:Button ID="BtnSubmit" CssClass="offset-md-3 col-md-4 btn btn-primary" runat="server" Text="Crear Producto" OnClick="BtnSubmit_Click" />
            </div>
            <div class="row mb-3 mt-4">
                <asp:Label ID="LblCreateOK" runat="server" Text="" CssClass="col-md-3" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</div>

    <%-- <h4>ULTIMOS PRODUCTOS CREADOS</h4>
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
        BackColor="#99CCFF"
        HeaderStyle-BackColor="Blue"
        HeaderStyle-ForeColor="White"
        AllowSorting="True"
        RowStyle-HorizontalAlign="Center"
        HeaderStyle-HorizontalAlign="Center"
        HeaderStyle-VerticalAlign="Middle"
        OnPageIndexChanging="gvProducts_PageIndexChanging">
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
    </asp:GridView>--%>
</asp:Content>
