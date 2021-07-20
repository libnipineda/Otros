<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="REmpresa.aspx.cs" Inherits="IPC2.REmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Titulo" runat="server" Text="Registro De Empresa" Font-Size="XX-Large"></asp:Label>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la empresa</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese dirección</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese telefono</asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Label">Ingrese e-mail</asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Label">Seleccione el tipo de empresa</asp:Label>
    </p>    
    <p>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Hotel" /></p>
    
    <p>
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Restaurante" /></p>
    <p>
        <asp:RadioButton ID="RadioButton3" runat="server" Text="Museo" /></p>
    <p>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Registrar Empresa" CssClass="button primary" OnClick="Button1_Click" />
    </p>
</asp:Content>