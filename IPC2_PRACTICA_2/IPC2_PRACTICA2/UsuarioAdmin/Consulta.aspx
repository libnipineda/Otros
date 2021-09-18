<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="IPC2_Practica.UsuarioAdmin.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Ingrese código del producto "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>    
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Filtrar Busqueda"></asp:Label>
         &nbsp;  &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="Si" OnClick="Button2_Click" />
    </p>    
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server" BorderStyle="Groove" CellPadding="1" CellSpacing="2"></asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <p>
            <asp:Label ID="Label3" runat="server" Text="Ingrese tipo de producto"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>            
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Ingrese material del producto"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Ingrese color del producto"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Buscar Producto" OnClick="Button3_Click" />
        </p>
        <p>
            <asp:GridView ID="GridView2" runat="server" Visible="False"></asp:GridView>
        </p>
    </asp:Panel>
</asp:Content>
