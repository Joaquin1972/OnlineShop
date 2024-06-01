<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

    <div class="header2">
        <div>
            <h4>LISTADO DE CATEGORIAS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="CategoryCreate.aspx">Volver a Crear Categorías</a>
        </div>
    </div>
    <hr />
    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        CssClass="alert alert-danger" />
    <asp:HiddenField ID="txtId" runat="server" />
    <div class="row justify-content-center">
        <div class="col-8">
            <div class="mb-3">
                <asp:GridView ID="gvCategories"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-bordered border-5 rounded"
                    BackColor="#99CCFF"
                    HeaderStyle-BackColor="Blue"
                    HeaderStyle-ForeColor="White"
                    AllowSorting="True"
                    RowStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center"
                    HeaderStyle-VerticalAlign="Middle"
                    DataKeyNames="Id"
                    OnSelectedIndexChanged="gvCategories_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" Visible="true">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CategoryName" HeaderText="Categorías actuales">
                            <ItemStyle Width="60%" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Width="30%" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />


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
                    ID="RequiredFieldValidator1"
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
                <asp:Button ID="txtUpdate" runat="server" CssClass="btn btn-primary w-100" Text="Actualizar" OnClick="txtUpdate_Click" />
            </div>
        </div>
        <div class="row justify-content-center mb-3">
            <div class="col-md-4">
                <asp:Button ID="txtDelete" runat="server" CssClass="btn btn-secondary w-100" Text="Eliminar" OnClick="txtDelete_Click" />
            </div>
        </div>
    </div>





    <%--<a href="CategoryCreate.aspx">Volver a Crear Categorías</a>--%>
</asp:Content>
