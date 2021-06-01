<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="CarritoWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="media">
            <img src="<%:ArticuloDetalle.UrlImagen %>" class="mr-3" alt="...">
            <div class="media-body">
                <h5 class="mt-0"><%:ArticuloDetalle.Nombre %></h5>
                <p><%:ArticuloDetalle.Descripcion %></p>
                <div class="precio">
                    <h4>$<%: ArticuloDetalle.Precio %></h4>
                    <a href="Carrito.aspx?id=<%:ArticuloDetalle.Id%>">Agregar al Carrito</a>
                    <a href="Productos.aspx">Volver</a>

                    <i class="fas fa-cart-plus"></i>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
