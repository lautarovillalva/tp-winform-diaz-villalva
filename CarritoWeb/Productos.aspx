<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CarritoWeb.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    

    <div class="card-columns productos">

    <asp:ListView ID="lvProductos" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
       
        <EditItemTemplate>
            <span style="">Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Nombre:
            <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
            <br />
            Descripcion:
            <asp:TextBox ID="DescripcionTextBox" runat="server" Text='<%# Bind("Descripcion") %>' />
            <br />
            IdMarca:
            <asp:TextBox ID="IdMarcaTextBox" runat="server" Text='<%# Bind("IdMarca") %>' />
            <br />
            IdCategoria:
            <asp:TextBox ID="IdCategoriaTextBox" runat="server" Text='<%# Bind("IdCategoria") %>' />
            <br />
            ImagenUrl:
            <asp:TextBox ID="ImagenUrlTextBox" runat="server" Text='<%# Bind("ImagenUrl") %>' />
            <br />
            Precio:
            <asp:TextBox ID="PrecioTextBox" runat="server" Text='<%# Bind("Precio") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
            <br />
            <br />
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No se han devuelto datos.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">Nombre:
            <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
            <br />
            Descripcion:
            <asp:TextBox ID="DescripcionTextBox" runat="server" Text='<%# Bind("Descripcion") %>' />
            <br />
            IdMarca:
            <asp:TextBox ID="IdMarcaTextBox" runat="server" Text='<%# Bind("IdMarca") %>' />
            <br />
            IdCategoria:
            <asp:TextBox ID="IdCategoriaTextBox" runat="server" Text='<%# Bind("IdCategoria") %>' />
            <br />
            ImagenUrl:
            <asp:TextBox ID="ImagenUrlTextBox" runat="server" Text='<%# Bind("ImagenUrl") %>' />
            <br />
            Precio:
            <asp:TextBox ID="PrecioTextBox" runat="server" Text='<%# Bind("Precio") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
            <br />
            <br />
            </span>
        </InsertItemTemplate>
        <ItemTemplate>

            <div class="card">

                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' />
                
                  <div class="card-body">
                      <h5> <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></h5>
                      <p><asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></p>
                  </div>

                <div class="precio">
                      <h4><asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>'></asp:Label></h4>
                      <asp:Button ID="btnAgregar" class="btn btn-outline-warning"  runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="eventoAgregar" OnCommand="btnAgregar_Command" Text="Agregar al carrito" UseSubmitBehavior="False" />
                </div>
           </div>
            
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span style="" />
                
                <span><span id="itemPlaceholder" runat="server"></span>
                <br />
                <br />
                </span>
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="">Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Nombre:
            <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
            <br />
            Descripcion:
            <asp:Label ID="DescripcionLabel" runat="server" Text='<%# Eval("Descripcion") %>' />
            <br />
            IdMarca:
            <asp:Label ID="IdMarcaLabel" runat="server" Text='<%# Eval("IdMarca") %>' />
            <br />
            IdCategoria:
            <asp:Label ID="IdCategoriaLabel" runat="server" Text='<%# Eval("IdCategoria") %>' />
            <br />
            ImagenUrl:
            <asp:Label ID="ImagenUrlLabel" runat="server" Text='<%# Eval("ImagenUrl") %>' />
            <br />
            Precio:
            <asp:Label ID="PrecioLabel" runat="server" Text='<%# Eval("Precio") %>' />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
    </asp:ListView>


      </div>

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CATALOGO_DBConnectionString %>" SelectCommand="SELECT [Id], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio] FROM [ARTICULOS]"></asp:SqlDataSource>



</asp:Content>
