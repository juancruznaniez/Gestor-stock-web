<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-mt5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                    <div class="mb-3">
                        <asp:label for="txtEmail" id="lblUser" class="form-label" runat="server">User</asp:label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" type="password" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3 form-check">
                        <asp:CheckBox ID="ckbRecuerdame" CssClass="form-check-input" runat="server" />
                        <label class="form-check-label" for="ckbRecuerdame">Recuerdame</label>
                    </div>
                    <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" type="submit" />
            </div>               
        </div>
    </div>
</asp:Content>
