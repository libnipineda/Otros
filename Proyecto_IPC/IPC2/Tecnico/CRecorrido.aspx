<%@ Page Title="" Language="C#" MasterPageFile="~/UTecnico.Master" AutoEventWireup="true" CodeBehind="CRecorrido.aspx.cs" Inherits="IPC2.Tecnico.CRecorrido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre del recorrido</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese fecha de inicio</asp:Label>
        &nbsp;<asp:TextBox ID="TextBox2" runat="server" ForeColor="Black" TextMode="Date"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese fecha final</asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black" TextMode="Date"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Label">Ingrese nombre de las empresas</asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black"></asp:TextBox>        
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Crear" CssClass="button primary" OnClick="Button1_Click" />
    </p>
</asp:Content>
