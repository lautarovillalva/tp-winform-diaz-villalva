<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoWeb.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <% if (carrito.Count != 0)
        { %>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="carrito container">
                <asp:Repeater runat="server" ID="repetidor">
                    <ItemTemplate>

                        <div class="articulo ">

                            <div class="nombre">
                                <asp:LinkButton ID="lnkEliminar" CommandName="eventoEliminar" CommandArgument='<%#Eval("Articulo.Id") %>' OnCommand="lnkEliminar_Command" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                                <img src='<%#Eval("Articulo.UrlImagen")%>' alt='<%# Eval("Articulo.Nombre")%>' />
                                <h3><%#Eval("Articulo.Nombre") %></h3>
                            </div>

                            <div class="cantidad">

                                <asp:Button ID="btnSumar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Articulo.Id") %>' CommandName="eventoSumar" OnCommand="btnSumar_Command" Text="+1" UseSubmitBehavior="false" />
                                <h3><%#Eval("Cantidad") %></h3>
                                <asp:Button ID="btnRestar" CssClass="btn btn-outline-warning" runat="server" CommandArgument='<%#Eval("Articulo.Id") %>' CommandName="eventoRestar" OnCommand="btnRestar_Command" Text="-1" UseSubmitBehavior="false" />

                            </div>
                            <div class="precio">

                            <span>$<%# Eval("Subtotal") %></span>
                            

                            </div>
                        </div>

                    </ItemTemplate>

                </asp:Repeater>

                <hr />
                <div class="total">

                    <asp:Button ID="btnVaciar" CssClass="btn btn-outline-warning" CommandName="eventoVaciar" OnCommand="btnVaciar_Command" Text="Vaciar Carrito" runat="server" UseSubmitBehavior="false" />
                    <h4>
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h4>
                </div>


            </div>



        </ContentTemplate>
    </asp:UpdatePanel>

    <%}
        else
        {%>

    <div class="carrito-vacio">

        <img src="https://www.imichile.cl/wp-content/uploads/2021/02/carro-vacio.png" />
        <h3>El carrito se encuntra vacio</h3>
    </div>

    <%} %>
</asp:Content>
