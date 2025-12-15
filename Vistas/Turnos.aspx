<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vistas.Turnos" %>

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
            width: 801px;
        }
        .auto-style3 {
            width: 220px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="height: 57px; margin-bottom: 1px;  background-color: #b71c1c">
            <br />
                <asp:Label ID="lblBienvenida" runat="server" ForeColor="White"  Text="    Bienvenido    " style="margin-left: 21px" Width="84px"></asp:Label>
                <asp:Label ID="lblUsuario" runat="server" BorderColor="White" ForeColor="White" Text="USUARIO"></asp:Label>
                &nbsp;
                <asp:Label ID="lblAccion" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Seccion administrador - Turnos" Width="266px"></asp:Label>
<br />

        </div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
        <asp:Button ID="asignarturno" runat="server" BackColor="#6666FF" ForeColor="White" Height="68px" style="text-align:center; margin-top:20px;" Text="Asignar turno" Width="197px" OnClick="asignarturno_Click" />

                    </td>
                <td>
        <asp:Button ID="btnInformeAsistencias" runat="server" BackColor="#6666FF" ForeColor="White" Height="68px" style="text-align:center; margin-top:20px;" Text="Informe de Asistencias" Width="197px" OnClick="btnInformeAsistencias_Click" />

                    </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
