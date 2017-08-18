<%@ Page Title="" Language="C#" MasterPageFile="~/master/masteruno.Master" AutoEventWireup="true" CodeBehind="AUsuarios.aspx.cs" Inherits="Presentacion.AUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="form-horizontal">
        <tr>
            <td>
                <asp:Label Text="" runat="server" ID="lblMensaje" CssClass="alert alert-dismissible alert-success" Visible ="false" />
            </td>

        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlAccion"  CssClass="form-control" OnSelectedIndexChanged="ddlAccion_SelectedIndexChanged">
                    <asp:ListItem Text="Crear" Value="1" />
                    <asp:ListItem Text="Modificar" Value="2" />
                    <asp:ListItem Text="Eliminar" Value="3" />
                </asp:DropDownList></td>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label Text="Id" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtId" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Identificación" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtIdentificacion" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdentificacion" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtIdentificacion" ErrorMessage="Sólo numeros" ValidationExpression="^[0-9]{1,12}?$" ValidationGroup="VG_Validacion"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Nombre" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNombre" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Dirección" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtDireccion" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDireccion" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Teléfono" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTelefono" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*" ValidationGroup="VG_Validacion"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo Numeros" ValidationExpression="^[0-9]{1,12}?$" ValidationGroup="VG_Validacion" ControlToValidate="txtTelefono"></asp:RegularExpressionValidator>
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
                <asp:TextBox runat="server" ID="txtEliminado" Visible="false" />
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
                <asp:Label Text="Seleccionar Usuario" runat="server" />
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlUsuarios" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>

    </table>
    <asp:GridView runat="server" ID="grdRegistros"  CssClass= "table table-striped table-hover "></asp:GridView>
</asp:Content>
