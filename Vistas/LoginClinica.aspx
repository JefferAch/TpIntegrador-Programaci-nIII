<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginClinica.aspx.cs" Inherits="Vistas.LoginClinica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">

        <div style="height: 57px; margin-bottom: 1px;  background-color: #b71c1c">
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="White" Text="CLÍNICA  -Login" 
                Font-Bold="True" Font-Size="Large" style="margin-left: 25px;"></asp:Label>
            
        </div>

        <div style="border-style: none; height: 379px; margin-top: 60px; width: 1386px;">
          <center>
                <h1>Iniciar Sesión</h1>

                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300" style="margin-left: 0px" Width="16px"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtUsuario" runat="server" Width="300px" OnTextChanged="txtUsuario_TextChanged"></asp:TextBox><br /><br />

                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300" style="margin-left: 0px" Width="16px"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox><br /><br />
                
                <asp:Label ID="lblPassword2" runat="server" Text="Repita la Contraseña:" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300" style="margin-left: 0px" Width="16px"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword2" runat="server" Width="300px" TextMode="Password" ></asp:TextBox><br />

              <asp:CompareValidator ID="CVPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" ErrorMessage="CompareValidator" ForeColor="Red" Display="Dynamic">Error: Contraseñas Diferentes</asp:CompareValidator>
                <br /><br />

                <asp:Label ID="lblTipoUser" runat="server" Text="Tipo de usuario:" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" ForeColor="Black" style="margin-left: 7px">
                    <asp:ListItem Value="0">Administrador</asp:ListItem>
                    <asp:ListItem Value="1">Médico</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lblERROR" runat="server" ForeColor="Red"></asp:Label>
                <br /><br />

                <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" Width="150px" BackColor="#3366FF" ForeColor="White" OnClick="BtnIngresar_Click"/>
            </center>
        </div>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
