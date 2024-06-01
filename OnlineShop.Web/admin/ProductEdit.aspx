<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="OnlineShop.Web.admin.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <%-- Cabecera de la página --%>
    <div class="header2">
        <h4>ACTUALIZAR PRODUCTO</h4>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="ProductList.aspx">Ver Listado</a>
        </div>
    </div>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" DisplayMode="List" />

    <div class="row  container-fluid" id="product" >
        <%--Creo dos columnas en pantalla, a la izda: fotografia, a la dcha: Resto de campos--%>
        <%--Columna izquierda--%>
        <%--Imagen del producto--%>
        <div class="col-md-4">
            <asp:Image ID="ProductImage" runat="server" Width="70%" CssClass="image" />
        </div>
        <%--Columna derecha--%>
        <div class="col-md-8">
            <asp:Label ID="ID" runat="server" Text="Label" Visible="false"></asp:Label>
            <%--Etiqueta y campo de texto para el nombre del producto--%>
            <div class="row mb-3">
                <div class="col-md-4 fw-bold">
                    <asp:Label ID="lblProduct"
                        AssociatedControlID="txtProduct"
                        runat="server"
                        Text="Nombre">
                    </asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtProduct"
                        runat="server"
                        CssClass="form-control w-100">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" Display="Dynamic"
                        ErrorMessage="El nombre es obligatorio"
                        Text="El nombre es obligatorio"
                        ControlToValidate="txtProduct">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <%--Etiqueta y campo de texto para la descripción del producto--%>
            <div class="row mb-3">

                <div class="col-md-4 fw-bold">
                    <asp:Label ID="lblDescription"
                        AssociatedControlID="txtDescription"
                        runat="server"
                        Text="Descripción">
                    </asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtDescription"
                        runat="server"
                        CssClass="form-control w-100" Rows="0" TextMode="MultiLine">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server" Display="Dynamic"
                        ErrorMessage="La descripción es obligatoria"
                        Text="La descripción es obligatoria"
                        ControlToValidate="txtDescription">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <%--Etiqueta y campo de texto para la categoría del producto--%>
            <div class="row mb-3">

                <div class="col-md-4 fw-bold">
                    <asp:Label ID="Label3"
                        AssociatedControlID="ddlCategory"
                        runat="server"
                        Text="Categoría a actualizar">
                    </asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlCategory"
                        runat="server"
                        CssClass="form-control w-100">
                    </asp:DropDownList>
                </div>
            </div>
            <%--Etiqueta y campo de texto para el precio del producto--%>
            <div class="row mb-3">

                <div class="col-md-4 fw-bold">
                    <asp:Label ID="Label1"
                        AssociatedControlID="txtPrice"
                        runat="server"
                        Text="Precio a actualizar">
                    </asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtPrice"
                        runat="server"
                        CssClass="form-control w-100">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server" Display="Dynamic"
                        ErrorMessage="El precio es obligatorio"
                        Text="El precio es obligatorio"
                        ControlToValidate="txtPrice">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1"
                        runat="server" Display="Dynamic"
                        ErrorMessage="Precio fuera de rango"
                        Text="Precio fuera de rango"
                        ControlToValidate="txtPrice"
                        MaximumValue="50" MinimumValue="0">
                    </asp:RangeValidator>
                </div>
            </div>
            <%--Etiqueta y campo de texto para el stock del producto--%>
            <div class="row mb-3">
                <div class="col-md-4 fw-bold">
                    <asp:Label ID="Label2"
                        AssociatedControlID="txtStock"
                        runat="server"
                        Text="Stock a actualizar">
                    </asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtStock"
                        runat="server"
                        CssClass="form-control w-100">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                        runat="server" Display="Dynamic"
                        ErrorMessage="El precio es obligatorio"
                        Text="El precio es obligatorio"
                        ControlToValidate="txtStock">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2"
                        runat="server" Display="Dynamic"
                        ErrorMessage="Stock fuera de rango"
                        Text="Stock fuera de rango"
                        ControlToValidate="txtStock"
                        MaximumValue="50" MinimumValue="0">
                    </asp:RangeValidator>
                </div>
            </div>
            <div class="row mb-3">
                <asp:Label ID="lblPhoto" runat="server" Text="Sube una foto" CssClass="col-md-4 fw-bold"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="col-md-4"></asp:FileUpload>
            </div>
            <div class="row mb-3">
                <asp:Button ID="btnUpload" runat="server" Text="Subir Archivo" CssClass="col-md-3 offset-4" />
                <asp:Label ID="UpLoadOK" runat="server" Text="" CssClass="col-md-3"></asp:Label>
            </div>
        </div>
    </div>
    <div>


        <div id="update" class="d-flex justify-content-center flex-column align-items-center">
            <h5>Modifica los campos que desees y pulsa Actualizar</h5>
            <asp:Button ID="btnSubmit" runat="server" Text="Actualizar" CssClass="btn btn-primary col-md-4 mt-3" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Borrar Producto" CssClass="btn btn-secondary col-md-4 mt-3 mb-2" OnClick="btnDelete_Click" />

        </div>





    </div>






</asp:Content>
