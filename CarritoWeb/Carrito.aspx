<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <%--    <div class="carrito">

        <% foreach (DOMINIO.Carro item in carrito)
            { %>

        <div class="articulo">

            <img src="<%: item.Articulo.UrlImagen %>" />
            <h3><%: item.Articulo.Nombre %></h3>
            <asp:Button ID="btnSumar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eventoSumar" OnCommand="btnSumar_Command" Text="+1" UseSubmitBehavior="false" />
            <h3><%:item.Cantidad %></h3>
            <asp:Button ID="btnRestar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eventoRestar" OnCommand="btnRestar_Command" Text="-1" UseSubmitBehavior="false" />
            <span><%: item.Subtotal %></span>

        </div>

        <%} %>
        <div>
            <h4>
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h4>
            <asp:Button ID="btnVaciar" CssClass="btn btn-outline-warning" CommandName="eventoVaciar" OnCommand="btnVaciar_Command"  Text="Vaciar Carrito" runat="server" UseSubmitBehavior="false" />
        </div>

    </div>--%>



    <div class="carrito">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="articulo">
                    <img src='<%#Eval("Articulo.UrlImagen")%>' alt='<%# Eval("Articulo.Nombre")%>' />
                    <h3><%#Eval("Articulo.Nombre") %></h3>
                    <asp:Button ID="btnSumar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Articulo.Id") %>' CommandName="eventoSumar" OnCommand="btnSumar_Command" Text="+1" UseSubmitBehavior="false"  />
                    <h3><%#Eval("Cantidad") %></h3>
                    <asp:Button ID="btnRestar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Articulo.Id") %>' CommandName="eventoRestar" OnCommand="btnRestar_Command" Text="-1" UseSubmitBehavior="false" />
                    <span><%# Eval("Subtotal") %></span>

                </div>

            </ItemTemplate>

        </asp:Repeater>

        <div>
            <h4>
                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h4>
            <asp:Button ID="btnVaciar" CssClass="btn btn-outline-warning" CommandName="eventoVaciar" OnCommand="btnVaciar_Command"  Text="Vaciar Carrito" runat="server" UseSubmitBehavior="false" />
        </div>






    </div>









</asp:Content>
