<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="Vistas.AgregarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            margin-bottom: 1px;
        }
        .auto-style2 {
            width: 486px;
        }
        .auto-style7 {
            width: 486px;
            height: 37px;
        }
        .auto-style8 {
            height: 37px;
        }
        .auto-style9 {
            height: 37px;
            width: 519px;
        }
        .auto-style10 {
            width: 519px;
        }
        .auto-style11 {
            width: 486px;
            height: 33px;
        }
        .auto-style12 {
            width: 519px;
            height: 33px;
        }
        .auto-style13 {
            height: 33px;
        }
        .auto-style14 {
            width: 486px;
            height: 23px;
        }
        .auto-style15 {
            width: 519px;
            height: 23px;
        }
        .auto-style16 {
            height: 23px;
        }
        .auto-style17 {
            width: 486px;
            height: 24px;
        }
        .auto-style18 {
            width: 519px;
            height: 24px;
        }
        .auto-style19 {
            height: 24px;
        }
        .auto-style20 {
            width: 486px;
            height: 27px;
        }
        .auto-style21 {
            width: 519px;
            height: 27px;
        }
        .auto-style22 {
            height: 27px;
        }
        .auto-style23 {
            width: 486px;
            height: 56px;
        }
        .auto-style24 {
            width: 519px;
            height: 56px;
        }
        .auto-style25 {
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div style="height: 57px; margin-bottom: 1px;  background-color: #b71c1c">
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="White"  Text="    Bienvenido    " style="margin-left: 21px" Width="84px"></asp:Label>
            <asp:Label ID="Label2" runat="server" BorderColor="White" ForeColor="White" Text="USUARIO"></asp:Label>
            &nbsp;
            <asp:Label ID="Label3" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Agregar paciente a la base de datos" Width="266px"></asp:Label>
            <br />
        <div style="border-style: none; height: 5px; ">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label4" runat="server" style="margin-left: 185px" Text="Nombre: "></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox1" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Nombre invalido" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label5" runat="server" style="margin-left: 185px" Text="Apellido:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox2" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Apellido invalido" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label6" runat="server" style="margin-left: 185px" Text="DNI:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox3" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="DNI invalido" ValidationExpression="^\d{7,8}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label7" runat="server" style="margin-left: 185px" Text="Email: "></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox4" runat="server" style="margin-top: 0px" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Mail invalido" ValidationExpression="^[^@\s]+@[^@\s]+.[^@\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label8" runat="server" style="margin-left: 185px" Text="Telefono:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBox5" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Telefono invalido" ValidationExpression="^11\d{8}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label9" runat="server" style="margin-left: 185px" Text="Provincia" Width="79px"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="487px" Height="22px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Seleccione provincia" ControlToValidate="DropDownList2"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="Label10" runat="server" style="margin-left: 183px" Text="Localidad:" Width="103px"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DropDownList3" runat="server" Width="487px" Height="22px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Seleccione localidad" ControlToValidate="DropDownList3"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" style="margin-left: 185px"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Direccion invalida" ValidationExpression="^[A-Za-z0-9áéíóúÁÉÍÓÚñÑ\s.,\-\/°]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" style="margin-left: 185px"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtNacionalidad" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Nacionalidad invalida" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23">
                        <asp:Label ID="lblGenero" runat="server" Text="Genero:" style="margin-left: 185px"></asp:Label>
                    </td>
                    <td class="auto-style24">
                        <asp:RadioButtonList ID="rblGenero" runat="server">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style25">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblGenero" ErrorMessage="Seleccione género"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de nacimiento:" style="margin-left: 185px"></asp:Label>
                    &nbsp;(yyyy/mm/dd)</td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtNacimiento" runat="server" Width="481px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNacimiento" ErrorMessage="Ingrese fecha de nacimiento"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20"></td>
                    <td class="auto-style21"></td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style21">
                        <asp:Label ID="lbltxt" runat="server" style="margin-left: 185px"></asp:Label>
                    </td>
                    <td class="auto-style22">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style12">
                        <asp:Button ID="Button1" runat="server" BackColor="#3366FF" ForeColor="White" Text="Agregar Paciente" Width="172px" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style13"></td>
                </tr>
                <tr>
                    <td class="auto-style17"></td>
                    <td class="auto-style18">
                        <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" Text="El paciente ya existe." Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style19">
                        <asp:HyperLink ID="HPatras" runat="server" NavigateUrl="ABMLPaciente.aspx">Volver Atras</asp:HyperLink>
                    </td>
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
            <br />
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

