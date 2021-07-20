<%@ Page Title="" Language="C#" MasterPageFile="~/UTecnico.Master" AutoEventWireup="true" CodeBehind="NServicio.aspx.cs" Inherits="IPC2.Tecnico.NServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la empresa</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>        
        
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button primary" ForeColor="Black" OnClick="Button1_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese nuevo servicio</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Agregar" CssClass="button icon" OnClick="Button2_Click" />
        </p>        
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese nombre de los platos a servir</asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Agregar" OnClick="Button3_Click" />
        </p>        
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Visible="False">
        <asp:Label ID="Label4" runat="server" Text="Label">Ingrese horario de atencion(hora de apertura)</asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Label">Ingrese horario de atencion(hora de cierre)</asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <p>
            *Nota: La tarifa es un valor unico cualquier duda llamar al instituto nacional de turismo.
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Agregar" OnClick="Button4_Click" />
        </p>
    </asp:Panel>
</asp:Content>
