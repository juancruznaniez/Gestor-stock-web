<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin1Ejemplo.aspx.cs" Inherits="Presentacion.MenuLogin1Ejemplo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <h1>Menu Login</h1>
            <hr />
        </div>
        <div class="col-4">
            <asp:Button ID="btnPagina1" CssClass="btn btn-primary" OnClick="btnPagina1_Click" runat="server" Text="Página user" />
        </div>
        <div class="col-4">
            <%if (Session["usuario"] != null && ((Entidades.Usuario)Session["usuario"]).TipoUsuario == Entidades.TipoUsuario.ADMIN)
              {%>
                  <asp:Button ID="btnPagina2" CssClass="btn btn-primary" OnClick="btnPagina2_Click" runat="server" Text="Página admin" />
                  <p>Tenes que ser admin</p>
           <% } %>
        </div>
    </div>
</asp:Content>
