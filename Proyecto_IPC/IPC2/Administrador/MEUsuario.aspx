<%@ Page Title="" Language="C#" MasterPageFile="~/UAdmin.Master" AutoEventWireup="true" CodeBehind="MEUsuario.aspx.cs" Inherits="IPC2.Administrador.MEUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Titulo" runat="server" Text="Label">Modificar o Eliminar Usuario</asp:Label>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Ingrese nombre de usuario(nickname)"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" BorderStyle="Solid"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="button primary" OnClick="Button1_Click" />
        &nbsp;<asp:Label ID="Aux" runat="server" Text="Label" ForeColor="Black" Visible="False"></asp:Label>
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <p>
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese nombre de la persona</asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="wrapper"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese e-mail</asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Label">Ingrese numero telefonico</asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Label">Ingrese nombre de usuario</asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Label">Ingrese contraseña</asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Label">Ingrese de nuevo la contraseña</asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="Label">Seleccione tipo de usuario</asp:Label>
    </p>
        <p>
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Agente Turistico" />
        </p>
        <p>
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Tecnico" />
        </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Actualizar Usuario" CssClass="button primary" OnClick="Button2_Click" Height="47px" Width="328px" />
    </p>
        <p>
            <asp:Button ID="Button3" runat="server" CssClass="button primary" Height="47px" OnClick="Button3_Click" Text="Eliminar Usuario" />
        </p>
    </asp:Panel>

</asp:Content>
