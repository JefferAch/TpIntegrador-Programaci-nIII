
<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="InformeAsistencias.aspx.cs"
    Inherits="Vistas.InformeAsistencias" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Informe de Asistencias</title>

<style type="text/css">
    .auto-style1 { width: 100%; height: 37px; }
    .auto-style2 { height: 37px; }
    .auto-style5 { height: 37px; width: 486px; }
    .auto-style6 { height: 37px; width: 504px; }
</style>
</head>

<body>
<form id="form1" runat="server">
    <div style="height:18px; background-color:#b71c1c; padding:15px;">
        <asp:Label ID="lblBienvenido" runat="server"
            Text="Bienvenido"
            ForeColor="White" />
        <asp:Label ID="lblUsuario" runat="server"
            ForeColor="White"
            Style="margin-left:10px;"
            Text="USUARIO" />
    </div>
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblTitulo" runat="server"
                    Text="Informe de Asistencias"
                    Font-Bold="True"
                    Font-Size="Large"
                    Style="margin-left:185px" />
            </td>
            <td class="auto-style6"></td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblDesde" runat="server"
                    Text="Desde:"
                    Style="margin-left:185px" />
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtDesde"
                    runat="server"
                    TextMode="Date"
                    Width="487px" />
            </td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblHasta" runat="server"
                    Text="Hasta:"
                    Style="margin-left:185px" />
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtHasta"
                    runat="server"
                    TextMode="Date"
                    Width="487px" />
            </td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btnGenerar"
                    runat="server"
                    Text="Generar Informe"
                    Width="202px"
                    BackColor="#3366FF"
                    ForeColor="White"
                    OnClick="btnGenerar_Click" />
            </td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblResultados" runat="server"
                    Text="Resultados:"
                    Font-Bold="True"
                    Style="margin-left:185px" />
            </td>
            <td class="auto-style6">
                <asp:GridView ID="gvAsistencias" runat="server"
    AutoGenerateColumns="False"
    Width="487px"
    BackColor="White"
    BorderColor="#b71c1c"
    BorderStyle="Solid"
    BorderWidth="2px"
    CellPadding="4"
    ForeColor="#333333"
    GridLines="None"
    OnRowDataBound="gvAsistencias_RowDataBound">
    <Columns>
        <asp:BoundField DataField="dia" HeaderText="Día" />
        <asp:BoundField DataField="horario" HeaderText="Horario" />
        <asp:BoundField DataField="Medico" HeaderText="Médico" />
        <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:Label ID="lblEstado" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Observaciones" HeaderText="Observación" />
    </Columns>
    <HeaderStyle BackColor="#b71c1c" ForeColor="White" Font-Bold="True" />
</asp:GridView>
            </td>
            <td class="auto-style2"></td>
        </tr>

        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblResumen" runat="server"
                    Text="Resumen General:"
                    Font-Bold="True"
                    Style="margin-left:185px" />
            </td>
            <td class="auto-style6">
                <asp:Label ID="lblPorcentajes" runat="server"
                    Font-Italic="True" />
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:HyperLink ID="hlVolver" runat="server"
                    NavigateUrl="IniciadoAdmin.aspx"
                    Text="Volver al menú de administrador."
                    ForeColor="#3366FF" />
            </td>
            <td class="auto-style2"></td>
        </tr>
    </table>
</form>
</body>
</html>