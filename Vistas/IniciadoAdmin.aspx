<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciadoAdmin.aspx.cs" Inherits="Vistas.IniciadoAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 416px;
        }
        .auto-style3 {
            width: 360px;
        }
        .auto-style4 {
            width: 416px;
            height: 30px;
        }
        .auto-style5 {
            width: 360px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="height: 57px; margin-bottom: 1px;  background-color: #b71c1c">
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="White"  Text="    Bienvenido    " style="margin-left: 21px" Width="84px"></asp:Label>
            <asp:Label ID="lblUsuario" runat="server" BorderColor="White" ForeColor="White" Text="USUARIO"></asp:Label>
            &nbsp;
            <asp:Label ID="Label3" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Interfaz de administrador" Width="266px"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" style="margin-left: 684px" Text="PRESIONE LA OPCIÓN DESEADA" Width="539px"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnABMLPac" runat="server" BackColor="#6666FF" ForeColor="White" Height="68px" style="margin-left: 115px" Text="ABML Pacientes" Width="197px" OnClick="btnABMLPac_Click" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnABMLMedicos" runat="server" BackColor="#6666FF" ForeColor="White" Height="68px" style="margin-left: 429px" Text="ABML Medicos" Width="197px" OnClick="btnABMLMedicos_Click" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnTurno" runat="server" BackColor="#6666FF" ForeColor="White" Height="68px" OnClick="btnTurno_Click" style="margin-left: 559px" Text="Asignacion de turnos" Width="197px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        </div>
    </form>
</body>
</html>
