<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryCreate.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <div class="header2">
        <div>
            <h4>CREAR CATEGORIAS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="CategoryList.aspx">Editar/Eliminar Categorías</a>
        </div>
    </div>
    <hr />
    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        CssClass="alert alert-danger" />

    <div class="container" id="update">
        <div class="row justify-content-center mb-3">
            <div class="col-md-4 text-center">
                <asp:Label ID="lblCategory"
                    runat="server" Text="Categoría"
                    CssClass="fw-bold"
                    AssociatedControlID="txtCategory">
                </asp:Label>
            </div>
        </div>
        <div class="row justify-content-center mb-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtCategory"
                    runat="server" CssClass="form-control">
                </asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ErrorMessage="El texto es obligatorio"
                    Text="El campo categoria es obligatorio"
                    ControlToValidate="txtCategory"
                    CssClass="text-danger">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row justify-content-center mb-3">
            <div class="col-md-4">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary w-100" Text="Actualizar" OnClick="BtnSubmit_Click" />
            </div>
        </div>


    </div>
    <%-- <div id="update">
        <div>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCategory" Text="Categoria:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ErrorMessage="El campo categoria es obligatorio"
                Text="El campo categoria es obligatorio"
                ControlToValidate="txtCategory">
            </asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Crear Categoría" CssClass="btn btn-primary" OnClick="BtnSubmit_Click" />
        </div>

    </div>--%>












    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered col-md-6" AlternatingRowStyle-BackColor="#CCCCCC">
        <Columns>
            <asp:BoundField DataField="CategoryId" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="CategoryName" HeaderText="Categorías actuales" />
        </Columns>
    </asp:GridView>
    <ul>
        <li><a href="CategoryList.aspx">Editar/Eliminar Categorías</a></li>
        <li><a href="admin.aspx">Volver Inicio Admin</a></li>
    </ul>

</asp:Content>

