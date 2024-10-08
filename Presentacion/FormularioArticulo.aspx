<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Presentacion.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <%-- Explicación:
 <div class="container mt-5">: Añade un contenedor con un margen superior (mt-5) para espaciar el formulario de la parte superior de la página.
<div class="row justify-content-center">: La clase justify-content-center alinea el formulario en el centro horizontalmente.--%>

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                <form>
                    <div class="mb-3">
                        <label for="txtId" class="form-label">ID</label>
                        <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Código</label>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca</label>
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="txtImagenUrl" class="form-label">URL imagen</label>
                                <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                                <br />
                                <asp:Image ImageUrl="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAN4AAACUCAMAAADLemePAAAAMFBMVEXx8/XCy9L09ve/yNDGztXN1Nrs7/HT2d/o6+7Z3uPh5enJ0dfk6Ovc4eXQ19zV299BB7LwAAAEOElEQVR4nO2a2baDIAwAkU0Utf//t9e17gUCgtyTea7LNBgSgBT/GpL6BZ4F9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9XIG9eLDgt3pXXq84KKsqupTdpqHuOF79BgXn0YRukBUW2rO/CL5Fj3Gq0GNbKFUqkp4Cb5Dj+lakr3bbEikKj0E36DHivZKbVWswLdOr9cPy8vA7QU1LILJ9ZhQBrlRUFYcIphaj1XSwm4U/AD8Uus1dnKjoHIPYFI9pi1Dtwg6j9CUeky42Q0BFG5+CfVYJ93kBj/i9gUm1Cud5UZql4o7nV7pODC/AZQOAzSVHgPGjowD1PoxifRYB7YbaG2fk0hPeNkR2lg+x1ePQcp5xv3shg/Qrtv10us70LLshPviget8d+VnlWA89Jhuxw5UNqXjlQ6V2D2ys3gSXI99vx9KbD+FiZ/dnQOdOX5gPbadt6jLbapAdoSWRj+oHtvnPqqAF/r5GSs0cPSaw6PM/+RkFyCtbDD5QfVOMbANX5C0Yu0H1TulB7tEzdqgcsbvD6jHjmPTPE5G/Goxdz+o3qlVo5WFHrdZNnLl1/wH1VMQPRb4w5sR4fXOg9OcOhm0xTOhQ+sVn1NquX/Ggn5Grud2hQmqd3pVi7rsHPFQ3C4Rgqf1+hA+cwFYPWbX9383/RFYT+9yJ22Nds8NzR/Ph5fUfONHa3NecV/1C+Dn0RDxZt7ZodI8KbBQXdCt32VZ4dWtd+0w/SmL3amQfcIdV1+/32JEwXusfnoqA8IjL/7lSCtlTw/NAarO/3QcvQhDc/BrTuGLo/dEJX3ld0qfMfRYsNUVI8fC91ovyImgLzqa3amp3umxQnftdDCoz/f1R/Agx7siZM2FY3rZ6LGiq+XmYNBw7qkuQQcSdjxYa1747eunVW+tQra/JrL2PNf1aK154bf7/FY9cXt4pgGemRm5aHwfZvu2ix479acbqAJsk8z3jZc1F7abR4ueqayoHY8kLHaRh+b0ric94/IjlU5b9l8iZs2Vdcdq1LMbQdJiR+YYvKhZc+U7PAc9216MuuaYGG3QJXJ5TzJs49t+/VQ6blRGqjXPL7oUn2Q4+uRwYf3bZx+843JTRObZjxTcaRHE4VgeE+nsyFycEecdKYs90YkUc8L6llPvR35N5zdXtlYNBU8yJ6xvOS4tga5UNhk09E6eM8NLAi811jCPbZdYM273Q681bVZGbGFv6WcH6KX096k1/eyatCUCrDfsWtwHMHFamemHp8fV6r7GfmYX1hnqVfJeLQuPaSVVLRYWer2px18SuwBcJFD9P2I3cdz6gpzefzP7Jv7xbbzYUCmKaaWQFbwMeh7uFVBSf4TmXIvqP311K5RIqZSS9F/aIQiCIAiCIAiCIAiCIAiCIAiCIAiCIAiCICn4A49MS2/QrYSCAAAAAElFTkSuQmCC"
                                    Width="100%" ID="imgArticulo" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                    <asp:Button ID="btnAceptar" runat="server" Text="Agregar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                    <asp:Button ID="btnInactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" runat="server" Text="Inactivar" />
                    <a href="ArticulosLista.aspx" class="btn btn-secondary ms-2">Cancelar</a>

                    <%if (ConfirmaEliminacion)
                        {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chkconfirmarEliminacion" runat="server" />
                        <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-outline-danger" />
                    </div>
                    <% } %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
            </div>
        </div>
    </div>

</asp:Content>
