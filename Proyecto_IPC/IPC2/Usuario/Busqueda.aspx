<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="IPC2.Usuario.Busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Ingrese nombre del sitio turistico o empresa"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Ingrese la region"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>    
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar sitio turistico" CssClass="button primary" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Buscar empresa" CssClass="button primary" OnClick="Button2_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView> 
    </asp:Panel>
</asp:Content>
