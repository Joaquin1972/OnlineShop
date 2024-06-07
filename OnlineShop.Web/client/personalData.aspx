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
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />


    <div id="form1" runat="server" class="form-container">
        <h3 class="form-title">Actualizar datos</h3>
        <div class="form-group">
            <asp:Label ID="LblName" runat="server" Text="Nombre" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBName" runat="server" CssClass="form-control mb-2" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre es obligatorio" Text="El nombre es obligatorio" ControlToValidate="TBName" ValidateRequestMode="Inherit" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="LblAdress" runat="server" Text="Dirección" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBAdress" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La dirección es obligatoria" Text="La dirección es obligatoria" ControlToValidate="TBAdress" ValidateRequestMode="Inherit" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="LbLCP" runat="server" Text="Código Postal" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCP" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El CP es obligatorio" Text="El CP es obligatorio" ControlToValidate="TBCP" ValidateRequestMode="Inherit" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label ID="LblCity" runat="server" Text="Ciudad" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCity" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="La ciudad es obligatoria" Text="La ciudad es obligatoria" ControlToValidate="TBCity" ValidateRequestMode="Inherit" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label ID="LblCountry" runat="server" Text="País" CssClass="fw-bold"></asp:Label>
            <asp:TextBox ID="TBCountry" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El país es obligatorio" Text="El país es obligatorio" ControlToValidate="TBCountry" ValidateRequestMode="Inherit" Display="Dynamic"></asp:RequiredFieldValidator>

        </div>
        <div class="text-center mt-4">
            <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar datos" CssClass="btn btn-primary " OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnReturn" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="BtnReturn_Click" />

        </div>
    </div>

</asp:Content>
