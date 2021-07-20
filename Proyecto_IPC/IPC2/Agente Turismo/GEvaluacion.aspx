<%@ Page Title="" Language="C#" MasterPageFile="~/UAgenteMaster.Master" AutoEventWireup="true" CodeBehind="GEvaluacion.aspx.cs" Inherits="IPC2.Agente_Turismo.GEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre del tecnico</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese nombre de la empresa</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" ForeColor="Black"></asp:TextBox>
    </P>
    <p>        
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button icon" OnClick="Button1_Click" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">        
        Tipo de Empresa: <asp:Label ID="Empresa" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese estado de la evaluacion</asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Crear Evaluación" CssClass="button primary" OnClick="Button2_Click" />
    </asp:Panel>    
</asp:Content>