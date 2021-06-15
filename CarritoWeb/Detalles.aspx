<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="CarritoWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <contenttemplate>
        

    <div class="container">


        <div class="card mb-3 detalle-articulo" style="margin-top: 40px">
            <div class="row no-gutters">
                 <div class="col-md-4">
                  <img src="<%:ArticuloDetalle.UrlImagen %>" alt="...">
                </div>
            <div class="col-md-4">
                <div class="card-body">
                  <h2 class="card-title"><%:ArticuloDetalle.Nombre %></h2>
                   <ul class="estrellas">
                       <li><i class="fas fa-star"></i></li>
                       <li><i class="fas fa-star"></i></li>
                       <li><i class="fas fa-star"></i></li>
                       <li><i class="fas fa-star"></i></li>
                       <li><i class="fas fa-star"></i></li>
                   </ul> 

                   <h3 class="precio">$<%:ArticuloDetalle.Precio %></h3> 

                   <hr />
                  <p class="card-text"><%:ArticuloDetalle.Descripcion %></p>
                  <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                </div>
             </div>
            
              <div class="col-md-3 botones"> 
                  <div class="detalles">
                      <span><i class="fas fa-truck"></i> Llega <b>mañana</b> gratis</span>
                      <br />
                      <span><i class="fas fa-redo"></i> Devolución gratis</span>
                      <p>Tenés 30 días desde que lo recibís.</p>
                  </div>
                  <div class="cantidad-detalle">
                      <h4>Cantidad:</h4>
                      <asp:Button class="btn btn-outline-primary" OnClick="btnSumar_Click" ID="btnSumar" runat="server" Text="+1" UseSubmitBehavior="False" />
                      <h5><%: cantidad %></h5>
                      <asp:Button class="btn btn-outline-primary" OnClick="btnRestar_Click" ID="btnRestar" runat="server" Text="-1"  UseSubmitBehavior="False"/>
                  </div>
                  <asp:Button ID="btnComprar" runat="server" Text="Comprar ahora" />
                  <asp:Button onclick="btnAgregar_Click" ID="btnAgregar" runat="server" Text="Agregar al carrito" UseSubmitBehavior="False" />
              </div>
            </div>
        </div>


    </div>

             <div runat="server" id="alert" class="alert alert-success" role="alert">
                        <%: ArticuloDetalle.Nombre %>  se ha agregado al carrito!
             </div>

  </contenttemplate>
    </asp:UpdatePanel>

</asp:Content>
