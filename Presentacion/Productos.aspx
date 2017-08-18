<%@ Page Title="" Language="C#" MasterPageFile="~/master/masteruno.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Presentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-condensed">
        <tr>
            <td>
                <asp:Label Text="Acción" runat="server" /></td>
            <td>
                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlAccion" OnSelectedIndexChanged="ddlAccion_SelectedIndexChanged" CssClass="form-control">
                    <asp:ListItem Text="Crear" Value="1" />
                    <asp:ListItem Text="Modificar" Value="2" />
                    <asp:ListItem Text="Eliminar" Value="3" />
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="" runat="server" ID="lblMensaje"  CssClass="alert alert-dismissible alert-success" Visible ="false"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtId" Enabled=" false" /></td>
        </tr>
        <tr>
            <td >
                <asp:Label Text="Nombre" runat="server" /></td>
            <td >
                <asp:TextBox runat="server" ID="txtNombre" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Cliente" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtCliente" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="VG_Validacion" ControlToValidate="txtCliente"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Eliminado" runat="server"  /></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlEliminado" CssClass="form-control">
                    <asp:ListItem Text="SI" Value="SI" />
                    <asp:ListItem Text="NO" Value="NO" />
                </asp:DropDownList>
                <asp:TextBox runat="server" ID="txtEliminado" Visible="false" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Seleccionar Producto" runat="server" /></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlproductos" AutoPostBack="true" OnSelectedIndexChanged="ddlproductos_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Crear" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" Enabled="false"  CssClass="btn btn-primary" ValidationGroup="VG_Validacion"/>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="false" OnClick="btnModificar_Click" CssClass="btn btn-primary" ValidationGroup="VG_Validacion" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Enabled="false" OnClick="btnEliminar_Click" CssClass="btn btn-primary" />
            </td>
            <td>&nbsp;</td>
        </tr>

    </table>

    <asp:GridView runat="server" ID="grdRegistros" CssClass="table table-striped table-hover "></asp:GridView>

</asp:Content>
