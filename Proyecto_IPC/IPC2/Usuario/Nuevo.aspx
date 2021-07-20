<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Nuevo.aspx.cs" Inherits="IPC2.Usuario.Nuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:label ID="Lable1" runat="server" text="Ingrese nombre de la empresa o sitio turistico"></asp:label>
        <asp:textbox ID="textbox1" runat="server"></asp:textbox>
    </p>    
    <p>
        <asp:button ID="button1" runat="server" text="Buscar Sitio Turistico" CssClass="button primary" OnClick="Unnamed3_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="Button7" runat="server" Text="Buscar Empresa" CssClass="button primary" OnClick="Button7_Click" />
    </p>
    <asp:panel  ID="panel1" runat="server" Visible="False">
        <asp:GridView ID="gridview1" runat="server"></asp:GridView>
        <asp:Button ID="button2" runat="server" Text="Like" Width="128px" OnClick="button2_Click"></asp:Button>
        &nbsp;&nbsp;
        <asp:Button ID="button3" runat="server" Text="Favorito" Width="176px" OnClick="button3_Click"></asp:Button>
        &nbsp;
        <asp:Button ID="Button4" runat="server" Text="Comentario" Width="229px" OnClick="Button4_Click" />
        &nbsp;
        <asp:Button ID="Button5" runat="server" Text="Compartir" Width="201px" OnClick="Button5_Click" />
        &nbsp;
        <asp:Button ID="Button6" runat="server" Text="Notificacion" OnClick="Button6_Click" />

    </asp:panel>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:panel ID="panel2" runat="server" Visible="False">
        <p>
           <asp:TextBox ID="textbox2" runat="server"></asp:TextBox>
           <asp:Button ID="comentar" runat="server" Text="Enviar" OnClick="comentar_Click" />
        </p>         
    </asp:panel>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            Recuerda utilizar @ para notificar a la persona Ej: @admin
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />       
        </p>        
    </asp:Panel>
</asp:Content>
