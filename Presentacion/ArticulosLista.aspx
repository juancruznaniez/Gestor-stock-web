<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="Presentacion.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <hr />
    <h1 style="text-align: center">Lista de articulos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control-sm m-xl-2 table-success bg-body" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
            </div>
        </div>
    </div>
    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro Avanzado" runat="server"
                CssClass=""
                ID="chkAvanzado"
                AutoPostBack="true"
                OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>
    <%if (chkAvanzado.Checked)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true" CssClass="form-switch alert-dismissible shadow-sm btn-group" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-switch alert-dismissible shadow-sm btn-group"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" ID="txtfiltroAvanzado" CssClass="form-switch alert-dismissible shadow-sm btn-group" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" runat="server"  OnClick="btnBuscar_Click"/>
            </div>
        </div>
    </div>
    <% }%>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table table-striped-columns alert-primary table-group-divider text-danger-emphasis" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                AllowPaging="True" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="ID" />
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="+" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button runat="server" Text="Agregar" ID="btnAgregarrr" OnClick="btnAgregarrr_Click" CssClass="btn-primary btn m-xl-2" />
</asp:Content>
