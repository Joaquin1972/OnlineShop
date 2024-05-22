<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <h4>LISTADO DE CATEGORIAS</h4>
    <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        CssClass="alert alert-danger" />
    <asp:HiddenField ID="txtId" runat="server" />
    <div class="mb-3">
        <asp:GridView ID="gvCategories"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-bordered col-md-6"
            AlternatingRowStyle-BackColor="#CCCCCC"
            DataKeyNames="Id"
            OnSelectedIndexChanged="gvCategories_SelectedIndexChanged">

            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="CategoryName" HeaderText="Categorías actuales" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <hr />
    <div class="row">
        <asp:Label ID="lblCategory" runat="server" Text="Categoría" CssClass="col-md-2 fw-bold" AssociatedControlID="txtCategory"></asp:Label>
        <asp:TextBox ID="txtCategory" 
            runat="server" CssClass="col-md-4"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server" 
            ErrorMessage="El texto es obligatorio" 
            Text="El campo categoria es obligatorio" 
            ControlToValidate="txtCategory">

        </asp:RequiredFieldValidator>
        <asp:Button ID="txtUpdate" runat="server" CssClass="offset-1 col-md-1" Text="Actualizar" OnClick="txtUpdate_Click" />
        <asp:Button ID="txtDelete" runat="server" CssClass="offset-1 col-md-1" Text="Eliminar" OnClick="txtDelete_Click" />
    </div>
    <hr />
    <a href="CategoryCreate.aspx">Volver a Crear Categorías</a>
</asp:Content>
