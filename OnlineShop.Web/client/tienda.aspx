﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tienda.aspx.cs" Inherits="OnlineShop.Web.client.tienda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .styled-ddl {
            display: flex;
            flex-direction: row;
            justify-content: center;
        }

        .container-ddl {
            padding: 20px;
            border: 1px solid black;
            width: 40%;
            margin: 0 auto 10px auto;
        }

        .makebig {
            transform: scale(1);
            transition: 0.5s;
        }

            .makebig:hover {
                transform: scale(2);
                border-radius: 5px;
                box-shadow: 2px 2px 2px black;
            }
    </style>
    <div class="justify-content-center col-md-12">
        <h1 class="bg-primary text-white p-1  rounded-4 text-center shadow">BIENVENIDO A NORABEL PLAY</h1>
        <h2 style="text-align: center; margin-bottom: 20px;">Aquí tienes nuestro stock</h2>
        <p class="lead text-center">Utiliza el menú desplegable para explorar nuestro catálogo completo o filtrar por una categoría específica.</p>
                <p class="lead text-center">Puedes pasar el cursor sobre la imagen para ampliarla y hacer clic en "Seleccionar" para obtener más detalles sobre el producto y proceder con la compra</p>

        <div class="justify-content-center container-ddl bg-primary rounded-4 shadow">
            <div class="text-center">
                <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>

    </div>

    <%--<asp:Button ID="btnFilter" runat="server" Text="Filtrar" OnClick="btnFilter_Click" />--%>


    <asp:DataList ID="dlProducts" 
        runat="server" 
        CssClass="table table-striped table-bordered border-5 rounded" 
        RepeatColumns="2" 
        BackColor="#99CCFF" 
        OnItemCommand="dlProducts_ItemCommand" 
        EditItemStyle-BorderStyle="Solid" 
        ClientIDMode="Predictable" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        RepeatLayout="Table" RepeatDirection="Horizontal" ItemStyle-Width="10" ItemStyle-HorizontalAlign="Justify" BorderWidth="3" BorderColor="White">    
        <ItemTemplate>
            <div class="text-center">
                <h4><%# Eval("Name") %></h4>
                <p><%# Eval("Id") %></p>
                <p class="fw-bold"><%# Eval("Description") %></p>
                <p class="fw-bold"><%# Eval("Price", "{0:n} €") %></p>
                <p><%# GetStockText((int)Eval("Stock")) %></p>
                <p><%# Eval("CategoryName") %></p>
                <p>
                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FirstImagePath") %>' Height="120" CssClass="makebig" />
                </p>
                <asp:Button ID="btnSelect" runat="server" Text="Seleccionar" CommandName="SelectProduct" cssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' />
                
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
  
</asp:Content>