<%@ Page Title="" Language="C#" MasterPageFile="~/master/masteruno.Master" AutoEventWireup="true" CodeBehind="OrdenesPorCliente.aspx.cs" Inherits="Presentacion.OrdenesPorCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                
                <asp:DropDownList runat="server" ID="ddlClientes" CssClass="form-control">
                </asp:DropDownList>
            
            </td>
            <td>
                <asp:Button Text="Buscar ordenes" runat="server" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView runat="server" ID="grdRegistros" CssClass="table table-striped table-hover"></asp:GridView>
</asp:Content>
