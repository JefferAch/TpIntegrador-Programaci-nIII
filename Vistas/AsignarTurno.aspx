<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 37px;
        }
        .auto-style2 {
            height: 37px;
        }
        .auto-style3 {
            height: 37px;
        }
        .auto-style4 {
            height: 37px;
        }
        .auto-style5 {
            height: 37px;
            width: 486px;
        }
        .auto-style6 {
            height: 37px;
            width: 504px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 57px; margin-bottom: 1px; background-color: #b71c1c">
            <asp:Label ID="lblBienvenidoAT"  runat="server" Text="Bienvenido" ForeColor="White"></asp:Label>
            <asp:Label style="margin-left: 10px" ID="lblUsuarioAT" runat="server" ForeColor="White" Text="   USUARIO"></asp:Label>
            
        </div>
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblIngresarEspecialidad" runat="server" style="margin-left: 185px" Text="Ingresar la Especialidad: "></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="dropDownEspecialidades" runat="server" Width="487px" AutoPostBack="True" OnSelectedIndexChanged="dropDownEspecialidades_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvAT" runat="server" ControlToValidate="dropDownEspecialidades" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblMedicoEspecialista" runat="server" style="margin-left: 185px" Text="Elegir Medico Especialista: "></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="DropdownEspecialistas" runat="server" Width="487px" AutoPostBack="True" OnSelectedIndexChanged="DropdownEspecialistas_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="rfvAT2" runat="server" ControlToValidate="DropdownEspecialistas" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td class="auto-style5">
                        <asp:Label ID="lblDias" runat="server" Text="Dia de atención:" style="margin-left: 183px"></asp:Label>
                    </td>
            <td class="auto-style6">
                        <asp:CheckBoxList ID="cblDias" runat="server">
                            <asp:ListItem>Lunes</asp:ListItem>
                            <asp:ListItem>Martes</asp:ListItem>
                            <asp:ListItem>Miércoles</asp:ListItem>
                            <asp:ListItem>Jueves</asp:ListItem>
                            <asp:ListItem>Viernes</asp:ListItem>
                            <asp:ListItem>Sábado</asp:ListItem>
                            <asp:ListItem>Domingo</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
            <td class="auto-style4">
                        <asp:CustomValidator ID="cvDias" runat="server" ErrorMessage="*"></asp:CustomValidator>
                    </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblPacienteTurno" runat="server" style="margin-left: 185px" Text="Paciente a Asignar Turno:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="DropdownPaciente" runat="server" Width="487px">
                </asp:DropDownList>
            </td>
            <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="rfvAT3" runat="server" ControlToValidate="DropdownPaciente" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
        </tr>
      
       
       
        <tr>
            <td class="auto-style5">
                        <asp:Label ID="lblHoraInicio" runat="server" Text="Hora del Turno:" style="margin-left: 183px"></asp:Label>
            </td>
            <td class="auto-style6">
                        <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time" Width="480px"></asp:TextBox>
            </td>
            <td class="auto-style4">
                        &nbsp;</td>
        </tr>
      
       
       
        <tr>
            <td class="auto-style5">
                        &nbsp;</td>
            <td class="auto-style6">
                        &nbsp;</td>
            <td class="auto-style4">
                        &nbsp;</td>
        </tr>
      
       
       
        <tr>
            <td class="auto-style5">
                <asp:HyperLink ID="hpInicioAdmin" runat="server" NavigateUrl="~/IniciadoAdmin.aspx">Volver al Inicio de Administrador</asp:HyperLink>
            </td>
            <td class="auto-style6">
                        <asp:Button style="text-align: center;" ID="btnAsignarTurno" runat="server" BackColor="#3366FF" ForeColor="White" Text="Asignar Turno" Width="202px" OnClick="btnAsignarTurno_Click" />
                    </td>
            <td class="auto-style2"></td>
        </tr>
      
       
       
    </table>
    </form>
    </body>
</html>
