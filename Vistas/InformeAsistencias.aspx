<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeAsistencias.aspx.cs" Inherits="Vistas.InformeAsistencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Informe de Asistencias</title>
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
        <div style="height: 57px; background-color: #b71c1c">
            <asp:Label ID="lblBienvenido" runat="server" Text="Bienvenido" ForeColor="White"></asp:Label>
            <asp:Label style="margin-left: 10px" ID="lblUsuario" runat="server" ForeColor="White" Text="USUARIO"></asp:Label>
        </div>

        <p>&nbsp;</p>

        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblTitulo" runat="server" Text="Informe de Asistencias" Font-Bold="True" Font-Size="Large" style="margin-left:185px"></asp:Label>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblDesde" runat="server" Text="Desde:" style="margin-left:185px"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtDesde" runat="server" TextMode="Date" Width="487px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblHasta" runat="server" Text="Hasta:" style="margin-left:185px"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtHasta" runat="server" TextMode="Date" Width="487px"></asp:TextBox>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    <asp:Button ID="btnGenerar" runat="server" BackColor="#3366FF" ForeColor="White" Text="Generar Informe" Width="202px" />
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblResultados" runat="server" Text="Resultados:" Font-Bold="True" style="margin-left:185px"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:GridView ID="gvAsistencias" runat="server" AutoGenerateColumns="True" Width="487px"
                                  BackColor="White" BorderColor="#b71c1c" BorderStyle="Solid" BorderWidth="2px"
                                  CellPadding="4" ForeColor="#333333" GridLines="None">
                        <HeaderStyle BackColor="#b71c1c" ForeColor="White" Font-Bold="True" />
                    </asp:GridView>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblResumen" runat="server" Text="Resumen General:" style="margin-left:185px" Font-Bold="True"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="lblPorcentajes" runat="server" Text="(ejemplo: 75% presentes 25% ausentes)" Font-Italic="True"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="IniciadoAdmin.aspx" Text="Volver al menú principal" ForeColor="#3366FF"></asp:HyperLink>
                </td>
                <td class="auto-style2"></td>
            </tr>
        </table>
    </form>
</body>
</html>
