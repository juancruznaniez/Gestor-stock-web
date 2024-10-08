<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola!</h1>
    <p>Llegaste a tu E-Commerce de confianza!</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%-- <%
            foreach (Entidades.Articulo Arti in ListaArticulos) // Se va a repetir tantas veces como elementos haya dentro de la grilla.
            {
        %>
            <div class="col">
                <div class="card">
                    <img src="<%: Arti.ImagenUrl %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: Arti.Nombre %></h5>
                        <p class="card-text"><%: Arti.Descripcion %></p>
                        <a href="DetalleArticulo.aspx?id=<%: Arti.Id %>">Ver detalle</a>
                    </div>
                </div>
            </div>
        <%  } %>--%>

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <h1>Título</h1>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
