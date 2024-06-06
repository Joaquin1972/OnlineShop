<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="personalData.aspx.cs" Inherits="OnlineShop.Web.client.personalData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .form-container {
            max-width: 600px;
            margin: 5% auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f8f9fa;
        }
        .form-title {
            text-align: center;
            margin-bottom: 20px;
        }
    </style>
    <div class="text-center mb-4">
        <h3>Hola, <%: Context.User.Identity.GetUserName()  %>, estás en tu área personal.<br />
            Aquí puedes actualizar tus datos personales.
        </h3>
    </div>

    <div id="form1" runat="server" class="form-container">
        <h3 class="form-title">Actualizar datos</h3>
        <div class="form-group">
            <asp:Label ID="LblName" runat="server" Text="Nombre" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBName" runat="server" CssClass="form-control mb-2" MaxLength="100"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblAdress" runat="server" Text="Dirección" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBAdress" runat="server" CssClass="form-control mb-2"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LbLCP" runat="server" Text="Código Postal" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCP" runat="server" CssClass="form-control mb-2"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblCity" runat="server" Text="Ciudad" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCity" runat="server" CssClass="form-control mb-2"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblCountry" runat="server" Text="País" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCountry" runat="server" CssClass="form-control mb-2"></asp:TextBox>
        </div>
        <div class="text-center">
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar datos" CssClass="btn btn-primary mt-4" OnClick="BtnUpdate_Click" />
        </div>
    </div>
   
</asp:Content>
