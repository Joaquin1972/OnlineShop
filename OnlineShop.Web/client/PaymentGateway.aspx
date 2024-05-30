<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentGateway.aspx.cs" Inherits="OnlineShop.Web.client.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pasarela de Pago</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
    <div id="form1" runat="server" class="container mt-2">
        <div class="form-group row">
            <%--Importe--%>
            <div class="col-md-2">
                <h3>
                    <label for="lblPaymentAmount" class="col-md-2 col-form-label fw-bold">Importe</label></h3>
            </div>
            <div class="col-md-2">
                <h3>
                    <asp:Label ID="lblPaymentAmount" runat="server" CssClass="form-control-plaintext fw-bold" Text="Label"></asp:Label></h3>
            </div>
        </div>
        <hr />
        <%-- Numero de tarjeta --%>
        <div class="form-group col mb-2 border-1">
            <label for="TBCardNumber" class="col-md-3 col-form-label fw-bolder">Nº Tarjeta</label>
            <div class="col-md-3">
                <asp:TextBox ID="TBCardNumber" runat="server" CssClass="form-control" MaxLength="16" OnKeyPress="return isNumberKey(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El número de tarjeta es obligatorio" Text="El número de tarjeta es obligatorio" ControlToValidate="TBCardNumber" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCardNumber" runat="server"
                    ControlToValidate="TBCardNumber"
                    ErrorMessage="El número de tarjeta debe ser exactamente 16 dígitos"
                    Text="El número de tarjeta debe ser exactamente 16 dígitos"
                    ValidationExpression="^\d{16}$"
                    CssClass="text-danger"
                    Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <%-- Fecha caducidad --%>
        <div class="form-group col mb-2">
            <label for="TBDate" class="col-md-3 col-form-label fw-bolder">Fecha de caducidad (mm/aa)</label>
            <div class="col-md-3">
                <asp:TextBox ID="TBDate" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="La fecha de caducidad es obligatoria"
                    Text="La fecha de caducidad es obligatoria"
                    ControlToValidate="TBDate"
                    CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revExpirationDate" runat="server"
                    ControlToValidate="TBDate"
                    ErrorMessage="Fecha de caducidad no válida"
                    ValidationExpression="^(0[1-9]|1[0-2])\/?([0-9]{2})$"
                    CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
        <%-- CCV --%>
        <div class="form-group col mb-2">
            <label for="TBCCV" class="col-md-3 col-form-label fw-bolder">CCV</label>
            <div class="col-md-3">
                <asp:TextBox ID="TBCCV" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="CCV es obligatorio" Text="CCV es obligatorio" ControlToValidate="TBCCV" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="CCV incorrecto" Text="CCV incorrecto" MaximumValue="999" ControlToValidate="TBCCV" MinimumValue="100" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
            </div>
        </div>
         <%-- Mensaje de aviso del pago ok/nok --%>
        <div class="form-group row mb-2">
            <div class="col-md-3">
                <asp:Label ID="lblMessage" runat="server" CssClass="form-control" Visible="false"></asp:Label>
            </div>
        </div>
        <%-- Botones de pago y cancelar --%>
        <div class="form-group row mb-2">
            <div class="col-md-3 mt-5">
                <asp:Button ID="btnPay" runat="server" CssClass="btn btn-primary" Text="Pagar" OnClick="btnPay_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancelar" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>



</asp:Content>
