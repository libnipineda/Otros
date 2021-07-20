<%@ Page Title="" Language="C#" MasterPageFile="~/UOpSis.Master" AutoEventWireup="true" CodeBehind="MUsuario.aspx.cs" Inherits="_IPC2_Fase2.Operador.MUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="major">Modificar o Eliminar Usuarios</h1>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Ingrese usuario"></asp:Label>            
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>            
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Estado" runat="server"></asp:Label>
            <asp:Label ID="Codigo" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="GridView1" runat="server" Visible="False">
            <EditRowStyle BorderStyle="Dotted" />
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <p>
            <asp:Label ID="Label2" runat="server" Text="Ingrese Carné"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Ingrese nombre"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Ingrese apellido"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Ingrese fecha de nacimiento "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" ForeColor="Black"></asp:TextBox>
            </p>                        
            <asp:Label ID="Label6" runat="server" Text="Ingrese e-mail"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Email"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Ingrese nickname"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Ingrese contraseña"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Ingrese palabra clave"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </asp:Panel>

        <p>
            <asp:Button ID="Button2" runat="server" Text="Actualizar" OnClick="Button2_Click" Visible="False" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" Visible="False" />
        </p>
    </form>
</asp:Content>
