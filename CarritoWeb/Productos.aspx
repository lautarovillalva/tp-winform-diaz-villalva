<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CarritoWeb.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="card-columns productos">

        <%  foreach (DOMINIO.Articulo item in lista)
            { %>
        <div class="card">
            <img src="<%: item.UrlImagen %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><%: item.Nombre %></h5>
                <p class="card-text"><%: item.Descripcion %></p>
            </div>

            <div class="precio">
                <h4>$<%: item.Precio %></h4>

                <%--<button type="button" class="btn btn-outline-warning">Sumar al carrito <i class="fas fa-cart-plus"></i></button>--%>
                <%--<asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" class="btn btn-outline-warning" Text="Sumar al carrito" runat="server" />--%>
                <a href="Carrito.aspx?id=<%:item.Id%>">Agregar al Carrito</a>
                
                <i class="fas fa-cart-plus"></i>
            </div>
        </div>

        <% }%>
    </div>



</asp:Content>
