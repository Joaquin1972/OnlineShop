<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="OnlineShop.Web.admin.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styles-admin.css" rel="stylesheet" />
    <%--<link href="../Content/tableList.css" rel="stylesheet" />--%>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">--%>
    <h3 style="text-align: center; font-weight: bold">ZONA ADMIN</h3>
    <hr />

        <div class="header2">
        <div>
            <h4>LISTADO DE PRODUCTOS</h4>
        </div>
        <div>
            <a href="admin.aspx">Volver Inicio Administrador</a>
            <a href="ProductCreate.aspx">Volver a Crear Productos</a>
        </div>
    </div>
    <hr />

        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" CssClass="mb-2">
        <asp:ListItem Text="5" Value="5" Selected="True"></asp:ListItem>
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="50" Value="50"></asp:ListItem>
    </asp:DropDownList>

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvProducts_PageIndexChanging" OnRowCommand="gvProducts_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Nombre *">
            <ItemTemplate>
                <asp:LinkButton ID="lnkName"  runat="server" Text='<%# Eval("Name") %>' CommandName="Select" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
            <asp:BoundField DataField="Description"  HeaderText="Descripción" />
            <asp:BoundField DataField="Price" HeaderText="Precio" DataFormatString="{0:n} €" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="CategoryName" HeaderText="Categoría" />
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <%--<asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />--%>
                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FirstImagePath") %>' Height="70" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>* Pulsa en el nombre del producto para editar o eliminar el producto</p>

    <%--<table id="products" class="tablemanager">
        <thead>
            <tr>
                <th>NOMBRE</th>
                <th class="disableSort">DESCRIPCION</th>
                <th>PRECIO</th>
                <th>STOCK</th>
                <th>CATEGORIA</th>
                <th class="disableSort">FOTOGRAFIA</th>

            </tr>
        </thead>
        <tbody>--%>
            <%--            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkName" runat="server" Text='<%# Eval("Name") %>' CommandArgument='<%# Eval("ID") %>' OnCommand="lnkName_Command" />
                        </td>
                        <td><%# Eval("Description") %></td>
                        <td><%# Eval("Price", "{0:n} €") %></td>
                        <td><%# Convert.ToDecimal(Eval("Stock")) %></td>
                        <td><%# Eval("Category.CategoryName") %></td>
                        <td>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>--%>

<%--            <asp:ListView ID="ProductsListView" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkName" runat="server" Text='<%# Eval("Name") %>' CommandArgument='<%# Eval("ID") %>' OnCommand="lnkName_Command" />
                        </td>
                        <td><%# Eval("Description") %></td>
                        <td><%# Eval("Price", "{0:n} €") %></td>
                        <td><%# Convert.ToDecimal(Eval("Stock")) %></td>
                        <td><%# Eval("Category.CategoryName") %></td>
                        <td>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="70" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>


    </table>--%>




<%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="../Content/tableManager.js"></script>
    <script type="text/javascript">
        // basic usage
        $('.tablemanager').tablemanager({
            firstSort: [[1, 0], [2, 0], [3, 0], [4, 0]],
            disable: ["last"],
            appendFilterby: true,
            dateFormat: [[4, "mm-dd-yyyy"]],
            debug: true,
            vocabulary: {
                voc_filter_by: 'Filtrar por',
                voc_type_here_filter: 'Filtrar ...',
                voc_show_rows: 'Productos por páginas '
            },
            pagination: false,
            showrows: [5, 10, 20, 50, 100],
            disableFilterBy: [2, 5]
        });
        // $('.tablemanager').tablemanager();
    </script>
    <script>
        try {
            fetch(new Request("https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js", { method: 'HEAD', mode: 'no-cors' })).then(function (response) {
                return true;
            }).catch(function (e) {
                var carbonScript = document.createElement("script");
                carbonScript.src = "//cdn.carbonads.com/carbon.js?serve=CK7DKKQU&placement=wwwjqueryscriptnet";
                carbonScript.id = "_carbonads_js";
                document.getElementById("carbon-block").appendChild(carbonScript);
            });
        } catch (error) {
            console.log(error);
        }
    </script>--%>
</asp:Content>
