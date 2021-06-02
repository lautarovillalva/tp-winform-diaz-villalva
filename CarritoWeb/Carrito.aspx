<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   

    <div class="carrito">

    <% foreach (DOMINIO.Articulo item in carrito)
        { %>

          <div class="articulo"> 

              <img src="<%: item.UrlImagen %>" />
              <h3><%: item.Nombre %></h3>
              <span><%: item.Precio %></span>

          </div>  

    <%} %>

    </div>
</asp:Content>
