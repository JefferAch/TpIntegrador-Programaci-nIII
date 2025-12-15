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
        }
        .auto-style4 {
            width: 1057px;
            height: 30px;
        }
        .auto-style5 {
        }
        .auto-style7 {
            width: 148px;
            height: 24px;
        }
        .auto-style8 {
            width: 357px;
            height: 24px;
        }
        .auto-style9 {
            width: 127px;
            height: 24px;
        }
        .auto-style10 {
            width: 78px;
            height: 24px;
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
                <asp:Label ID="lblAccion" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Turnos Asignados a Medico" Width="266px"></asp:Label>
<br />

        </div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5" rowspan="6">&nbsp;</td>
                    <td class="auto-style2" colspan="4">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Turnos Asignados" ></asp:Label>
                    </td>
                    <td rowspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="4">&nbsp; 
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDClinicaConnectionString %>" SelectCommand="SELECT [Legajo_Medico] FROM [Medico]"></asp:SqlDataSource>
                        <div style="margin: 20px 0;">
    <asp:Label ID="lblMedico" runat="server" Text="Seleccionar Médico: " Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="ddlMedicos" runat="server" Height="30px" Width="200px" DataSourceID="SqlDataSource1" DataTextField="Legajo_Medico" DataValueField="Legajo_Medico">
    </asp:DropDownList>

    <br /><br />

</div></td>
                </tr>
                <tr>
                    <td class="auto-style4" Align="center" colspan="4">
    <asp:Button ID="Button2" runat="server" Text="Limpiar" OnClick="btnMostrarTodos_Click" />
    <asp:Button ID="btnMostrarTodos" runat="server" Text="Ver Todos" OnClick="btnMostrarTodos_Click" Height="26px" Width="80px" style="margin-left: 440px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
    <asp:Label ID="lblFiltrar" runat="server" Text="Ordenar Turnos por: " Font-Bold="True"></asp:Label>
    
                    </td>
                    <td class="auto-style9">
    
    <asp:DropDownList ID="ddlFiltro" runat="server" Height="30px" Width="180px">
        <asp:ListItem Value="0">Seleccionar Filtro</asp:ListItem>
<asp:ListItem Value="1">DNI del Paciente</asp:ListItem>
        <asp:ListItem Value="2">Estado</asp:ListItem>
    </asp:DropDownList>

                    </td>
                    <td class="auto-style10">
    
    <asp:TextBox ID="txtFiltro" runat="server" Height="16px" Width="200px" placeholder="Ingrese búsqueda..." style="margin-bottom: 0px"></asp:TextBox>
    
                    </td>
                    <td class="auto-style8">
                        <div style="margin: 20px 0;">

    <asp:Button ID="btnFiltrar" runat="server" Text=" Buscar" OnClick="btnFiltrar_Click" BackColor="#284775" ForeColor="White" Height="30px" Width="80px" />
    
</div>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" align ="center" colspan="4">
                        <asp:GridView ID="GridView1" runat="server"
    Width="361px"
    AllowPaging="True"
    AutoGenerateColumns="False"
    AutoGenerateEditButton="True"
    CellPadding="4"
    ForeColor="#333333"
    GridLines="None"
    DataKeyNames="ID_Turno"
    OnRowDataBound="GridView1_RowDataBound"
    OnRowEditing="GridView1_RowEditing"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnPageIndexChanging="GridView1_PageIndexChanging">

    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

    <Columns>
        <asp:TemplateField HeaderText="Turno">
            <ItemTemplate>
                <asp:Label ID="lb_it_Turno" runat="server" Text='<%# Bind("ID_Turno") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Paciente">
  <ItemTemplate>
    <asp:Label ID="lb_it_Paciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
  </ItemTemplate>
</asp:TemplateField>


        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <asp:Label ID="lb_it_Estado" runat="server"></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:DropDownList ID="ddlEstadoEdit" runat="server">
                    <asp:ListItem Text="Pendiente" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Presente" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Ausente" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Observacion">
            <ItemTemplate>
                <asp:Label ID="lb_it_Observacion" runat="server"></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="txtObservacionEdit" runat="server" Width="220px"></asp:TextBox>
            </EditItemTemplate>
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
                </tr>
                <tr>
                    <td class="auto-style2" align ="center" colspan="4">
                        &nbsp;</td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>