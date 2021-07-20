<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="IPC2.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p>
        <asp:Label ID="Label1" runat="server" Text="Label">Ingrese nombre de la empresa</asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Buscar Empresa" CssClass="button primary" OnClick="Button1_Click" Height="43px" Width="256px" />
    </p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
         Empresa tipo:
        <asp:Label ID="TipoE" runat="server" Text=""></asp:Label>
        <p>
        <br / /> Inserte Imagen
        <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Black" />                                         
        <br /> Ingrese titulo de imagen:      
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Seleccione la region donde se encuetra la empresa"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="nombre"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="SELECT [nombre] FROM [Region]"></asp:SqlDataSource>
     </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <asp:Label ID="Label2" runat="server" Text="Label">Ingrese servicios que dispone el hotel</asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" ForeColor="Black"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Agregar" CssClass="button icon" OnClick="Button2_Click" />
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <asp:Label ID="Label3" runat="server" Text="Label">Ingrese nombre de los platos a servir</asp:Label>
          <asp:TextBox ID="TextBox4" runat="server" ForeColor="Black"></asp:TextBox>
          <asp:Button ID="Button3" runat="server" Text="Agregar" CssClass="button icon" OnClick="Button3_Click" />
    </asp:Panel>

    <asp:Panel ID="Panel4" runat="server" Visible="False">
         <p>
          <asp:Label ID="Label4" runat="server" Text="Label">Ingrese horario de atencion(hora de apertura)</asp:Label>
          &nbsp;
          <asp:TextBox ID="TextBox5" runat="server" ForeColor="Black" TextMode="Time"></asp:TextBox>
        </p>
        <p>
          <asp:Label ID="Label5" runat="server" Text="Label">Ingrese horario de atencion(hora de cierre)</asp:Label>
          &nbsp;
          <asp:TextBox ID="TextBox6" runat="server" ForeColor="Black" TextMode="Time"></asp:TextBox>          
        </p>     
        <p>
            *Nota: La tarifa es un valor unico cualquier duda llamar al instituto nacional de turismo.
        </p>
        <asp:Button ID="Button4" runat="server" Text="Agregar" OnClick="Button4_Click" />
    </asp:Panel>
</asp:Content>
