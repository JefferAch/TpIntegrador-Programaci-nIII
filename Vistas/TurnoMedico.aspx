<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnoMedico.aspx.cs" Inherits="Vistas.WebClinica" %>

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
            width: 1057px;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            width: 1057px;
            height: 30px;
        }
        .auto-style5 {
            width: 16px;
        }
        .auto-style6 {
            height: 30px;
            width: 16px;
        }
        .auto-style7 {
            width: 148px;
            height: 24px;
        }
        .auto-style8 {
            width: 662px;
            height: 24px;
        }
        .auto-style9 {
            width: 238px;
            height: 24px;
        }
        .auto-style10 {
            width: 78px;
            height: 24px;
        }
        .auto-style11 {
            width: 16px;
            height: 24px;
        }
        .auto-style12 {
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 57px; margin-bottom: 1px;  background-color: #b71c1c">
            <br />
                <asp:Label ID="lblBienvenida" runat="server" ForeColor="White"  Text="    Bienvenido    " style="margin-left: 21px" Width="84px"></asp:Label>
                <asp:Label ID="lblUsuario" runat="server" BorderColor="White" ForeColor="White" Text="USUARIO"></asp:Label>
                &nbsp;
                <asp:Label ID="lblAccion" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Turnos Asignados a Medico" Width="266px"></asp:Label>
<br />

        </div>
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2" colspan="4">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2" colspan="4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style4" Align="center" colspan="4">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Turnos Asignados" ></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style7">
                        <asp:Label ID="lblBuscador" runat="server" Text="Barra de Busqueda:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox1" style="margin-left: 15px" runat="server" OnTextChanged="TextBox1_TextChanged" Width="164px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="lblFiltrado" runat="server" Text="Filtrar por:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-left: 0px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style2" align ="center" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" Width="361px" AllowPaging="True" AutoGenerateEditButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Turno">
                                    <ItemTemplate>
                                        <asp:Label ID="lb_it_Turno" runat="server" Text='<%# Bind("ID_Turno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paciente">
                                    <ItemTemplate>
                                        <asp:Label ID="lb_it_Paciente" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lb_it_Estado" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observacion">
                                    <ItemTemplate>
                                        <asp:Label ID="lb_it_Observacion" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>