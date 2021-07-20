<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="CrearU.aspx.cs" Inherits="IPC2.Administrador.CrearU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Titulo" runat="server" Text="Registrar Usuario" Font-Size="X-Large"></asp:Label>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la persona</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese e-mail</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" TextMode="Email"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese numero telefonico</asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" TextMode="Phone"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Label">Ingrese nombre de usuario</asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Label">Ingrese contraseña</asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Label">Ingrese de nuevo la contraseña</asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Label">Seleccione tipo de usuario</asp:Label>
    </p>
    <p>
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Agente Turistico" />
    </p>
    <p>
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Tecnico" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Crear Usuario" BorderStyle="Groove" CssClass="button primary" OnClick="Button1_Click" />
    </p>
</asp:Content>
