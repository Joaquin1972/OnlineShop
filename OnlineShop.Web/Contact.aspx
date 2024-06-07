<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="OnlineShop.Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <%--<h2 id="title"><%: Title %></h2>--%>
        <h3>Norabel Play, nos tienes en Zaragoza</h3>
        <address>
            50016 - Zaragoza<br />
            <%--Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100--%>
        </address>
       <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2980.3131245054283!2d-0.8377115235242382!3d41.67058047838087!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd591404619eb89b%3A0x56b8fb9dc0c5517e!2sC.%20Jos%C3%A9%20Antonio%20Rey%20del%20Corral%2C%20Santa%20Isabel%2C%2050016%2C%20Zaragoza!5e0!3m2!1ses!2ses!4v1717748283790!5m2!1ses!2ses" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>

        <address>
            <strong>Correo:</strong>   <a href="mailto:norabelplay@gnail.com">Mandanos un correo</a><br />
            <%--<strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
        </address>
       
    </main>
</asp:Content>
