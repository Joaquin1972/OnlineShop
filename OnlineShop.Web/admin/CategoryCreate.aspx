<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryCreate.aspx.cs" Inherits="OnlineShop.Web.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />
    <h4>CREAR CATEGORIAS</h4>
    <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        CssClass="alert alert-danger" />
    <hr />
    <div class="row mb-2">
        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtCategory" Text="Introduce el nombre de la categoria" CssClass="col-md-4 fw-bold"></asp:Label>
        <asp:TextBox ID="txtCategory" runat="server" CssClass="col-md-8"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server" 
            ErrorMessage="El campo categoria es obligatorio" 
            Text="El campo categoria es obligatorio" 
            ControlToValidate="txtCategory">
        </asp:RequiredFieldValidator>
    </div>
    <div class="row mb-2">
        <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="offset-4 col-md-1" OnClick="BtnSubmit_Click" />
        <asp:Button ID="btnList" runat="server" Text="Modificar Categorías" CssClass="offset-1 col-md-2"/>
    </div>

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
 
