<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="IPC2.Administrador.Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:label ID="label1" runat="server" text="Ingrese sitio turistico o empresa"></asp:label>
        <asp:textbox ID="textbox1" runat="server"></asp:textbox>
    </p>    
    <p>
        <asp:button ID="button1" runat="server" text="Buscar sitio turistico" OnClick="Unnamed1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button ID="Button2" runat="server" text="Buscar empresa" OnClick="Button2_Click" />
    </p>
    <asp:panel ID="Panel1" runat="server" Visible="False">
        <p>
            <asp:Label ID="label2" runat="server" Text="Ingrese noticia"></asp:Label>
            <asp:TextBox ID="Textbox2" runat="server"></asp:TextBox>
            <asp:Label ID="label3" runat="server" Text="iIngrese titulo"></asp:Label>
            <asp:TextBox ID="Textbox3" runat="server"></asp:TextBox>
            Seleccione imagen:
            <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black"></asp:FileUpload>
        </p>        
        <p>
            <asp:Button ID="Button3" runat="server" Text="Crear noticia sitio" OnClick="Button3_Click" CssClass="button primary"></asp:Button>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Crear noticia empresa" CssClass="button primary" OnClick="Button4_Click"></asp:Button>
        </p>
    </asp:panel>
</asp:Content>