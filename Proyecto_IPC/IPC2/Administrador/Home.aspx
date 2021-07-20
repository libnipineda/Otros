<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IPC2.Administrador.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="titulo" runat="server" Text="Label">Datos de Usuario</asp:Label>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Nombre: </asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="nombreU" runat="server" Text=""></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label">E-mail: </asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="correo" runat="server" Text=""></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Label">Nickname: </asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="user" runat="server" Text=""></asp:Label>
    </p>    
</asp:Content>