<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CarritoWeb.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>

    <div class="card-columns container productos">
        <asp:Repeater ID="rpProductos" runat="server">
               <ItemTemplate>


                 <div class="card">

                     <a href="Detalles.aspx?id=<%# Eval("Id") %>"> 
                         <img src="<%# Eval("UrlImagen") %>" />
                     </a>

                    <div class="card-body">
                       <h5> <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></h5>
                       <p><asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></p>
                    </div>

                    <div class="precio">
                       <h4>$<asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>'></asp:Label></h4>
                       <asp:Button ID="btnAgregar" class="btn btn-outline-warning"  runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="eventoAgregar" OnCommand="btnAgregar_Command" Text="Agregar al carrito" UseSubmitBehavior="False" />
                    </div>
                 </div>

                  

               </ItemTemplate>
        </asp:Repeater>
    </div>

                    <div runat="server" id="alert" class="alert alert-success" role="alert">
                        <%: producto %>  se ha agregado al carrito!
                     </div>

        </contenttemplate>
    </asp:UpdatePanel>


   

</asp:Content>
