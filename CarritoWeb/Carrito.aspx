<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

    <div class="carrito">

    <% foreach (DOMINIO.Carro item in carrito)
        { %>

          <div class="articulo"> 

              <img src="<%: item.Articulo.UrlImagen %>" />
              <h3><%: item.Articulo.Nombre %></h3>
              <span><%: item.Subtotal %></span>

          </div>  

    <%} %>

    </div>
</asp:Content>
