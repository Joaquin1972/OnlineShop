<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tienda.aspx.cs" Inherits="OnlineShop.Web.client.tienda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .styled-ddl {
            display: flex;
            flex-direction: row;
            justify-content: center;
        }

        .container-ddl {
            padding: 15px;
            border: 1px solid black;
            width: 20%;
            margin: 0 auto 10px auto;
        }

        .makebig {
            z-index: 100;
            transform: scale(1);
            transition: 0.5s;
        }

            .makebig:hover {
                transform: scale(1.3);
                border-radius: 5px;
                box-shadow: 2px 2px 2px black;
            }
    </style>
    <div class="justify-content-center col-md-12">
        <%--<h1 class="bg-primary text-white p-1  rounded-4 text-center shadow">BIENVENIDO A NORABEL PLAY</h1>--%>
        <h2 style="text-align: center; margin-bottom: 20px;">Aquí tienes nuestro stock</h2>
        <p class="lead text-center">Utiliza el menú desplegable para explorar nuestro catálogo completo o filtrar por una categoría específica.</p>
        <p class="lead text-center">Pulsa anterior o siguiente para ver otros productos.</p>
        
        <p class="lead text-center">Puedes pasar el cursor sobre la imagen para ampliarla y hacer clic en "Seleccionar" para obtener más detalles sobre el producto y proceder con la compra</p>

        <%-- Desplegable para seleccionar categoría --%>
        <div class="justify-content-center container-ddl bg-primary rounded-4 shadow">
            <div class="text-center">
                <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>

    </div>



    <div class="container mt-4">
        <div class="mb-3">
        <%-- Botones de anterior y posterior --%>
        <asp:Button ID="btnPrev" runat="server" Text="Anterior" OnClick="btnPrev_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnNext" runat="server" Text="Siguiente" OnClick="btnNext_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblPageInfo" runat="server" CssClass="btn btn-info btn-sm disabled"></asp:Label> </div>
        <%-- Listado de productos --%>
        <asp:DataList ID="dlProducts" runat="server" CssClass="table table-striped table-bordered border-5 rounded"
            BackColor="#99CCFF" OnItemCommand="dlProducts_ItemCommand"
            EditItemStyle-BorderStyle="Solid" GridLines="Both" HorizontalAlign="Center"
            RepeatLayout="Table" RepeatDirection="Horizontal" BorderWidth="3"
            BorderColor="White" CellPadding="1" RepeatColumns="2" ItemStyle-Width="50%">
            <ItemTemplate>
                <div class="text-center">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-4 text-center">
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FirstImagePath") %>' Height="200" CssClass="makebig border rounded-2 mt-2 mb-2" />
                            </div>
                            <div class="col-md-8">
                                <h4><%# Eval("Name") %></h4>
                                <h5><%# Eval("CategoryName") %></h5>
                                <p class="fw-bolder"><%# Eval("Price", "{0:n} €") %></p>
                                <p><%# GetStockText((int)Eval("Stock")) %></p>
                                <asp:Button ID="btnSelect" runat="server" Text="Seleccionar" CommandName="SelectProduct" CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <asp:Button ID="btnPrevBottom" runat="server" Text="Anterior" OnClick="btnPrev_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnNextBottom" runat="server" Text="Siguiente" OnClick="btnNext_Click" CssClass="btn btn-primary" />

         <asp:Label ID="lblPageInfoBottom" runat="server" CssClass="btn btn-info btn-sm disabled"></asp:Label>
       
    </div>
    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

</asp:Content>




