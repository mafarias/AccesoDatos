<%@ Page Title="" Language="C#" MasterPageFile="~/master/masteruno.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="Presentacion.Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="form-horizontal">
        <tr>
            <td>
                <asp:Label Text="" runat="server" ID="lblMensaje" />
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label Text="Acción" runat="server" />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlAccion" AutoPostBack="true" OnSelectedIndexChanged="ddlAccion_SelectedIndexChanged" CssClass="form-control">
                    <asp:ListItem Text="Crear" Value="1" />
                    <asp:ListItem Text="Modificar" Value="2" />
                    <asp:ListItem Text="Eliminar" Value="3" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="ID" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtID" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="NoOrden" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNoOrden" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOrden" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNoOrden" ErrorMessage="Sólo numeros" ValidationExpression="^[0-9]{1,12}?$" ValidationGroup="VG_Validacion"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Cliente" runat="server" />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlClientes" CssClass="form-control">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Productos" runat="server" />
            </td>
            <td>
                <asp:ListBox ID="LsbProductos" runat="server" SelectionMode="Multiple"  CssClass="form-control"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Eliminado" runat="server" />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlEliminado" CssClass="form-control">
                    <asp:ListItem Text="SI" Value="SI" />
                    <asp:ListItem Text="NO" Value="NO" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Crear" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" Enabled="false" ValidationGroup="VG_Validacion" />
                <asp:Button Text="Modificar" runat="server" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" Enabled="false" ValidationGroup="VG_Validacion" />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-primary" Enabled="false" />
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label Text="Selecciona Orden" runat="server" />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlOrdenes" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlOrdenes_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    <asp:GridView runat="server" ID="grdRegistros" CssClass="table table-striped table-hover"></asp:GridView>
</asp:Content>
