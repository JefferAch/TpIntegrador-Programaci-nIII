<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Vistas.AgregarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 376px;
            margin-top: 0px;
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
            height: 30px;
        }
        .auto-style12 {
            width: 519px;
            height: 30px;
        }
        .auto-style13 {
            height: 30px;
        }
        .auto-style14 {
            width: 483px;
        }
        .auto-style15 {
            width: 525px;
        }
        .auto-style16 {
            width: 486px;
            height: 33px;
        }
        .auto-style17 {
            width: 519px;
            height: 33px;
        }
        .auto-style18 {
            height: 33px;
        }
        .auto-style19 {
            width: 483px;
            height: 25px;
        }
        .auto-style20 {
            width: 525px;
            height: 25px;
        }
        .auto-style21 {
            height: 25px;
        }
        .auto-style22 {
            width: 483px;
            height: 23px;
        }
        .auto-style23 {
            width: 525px;
            height: 23px;
        }
        .auto-style24 {
            height: 23px;
        }
        .auto-style25 {
            width: 100%;
        }
        .auto-style26 {
            width: 482px;
        }
        .auto-style27 {
            width: 523px;
        }
        .auto-style28 {
            width: 483px;
            height: 26px;
        }
        .auto-style29 {
            width: 525px;
            height: 26px;
        }
        .auto-style30 {
            height: 26px;
        }
        .auto-style31 {
            width: 481px;
        }
        .auto-style32 {
            width: 522px;
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
            <asp:Label ID="lblAccion" runat="server" ForeColor="White" style="margin-left: 1364px; margin-top: 0px" Text="Agregar médico a la base de datos" Width="266px"></asp:Label>
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
                        <asp:Label ID="lblNombre" runat="server" style="margin-left: 185px" Text="Nombre: "></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtNombre" runat="server" Width="480px" placeholder="Ingrese nombre del médico"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,12}$" ErrorMessage="Nombre invalido." ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblApellido" runat="server" style="margin-left: 185px" Text="Apellido:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtApellido" runat="server" Width="480px" placeholder="Ingrese apellido del médico"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Apellido invalido." ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,12}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblDni" runat="server" style="margin-left: 185px" Text="DNI:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtDni" runat="server" Width="480px" placeholder="DNI sin puntos ni espacios"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" ErrorMessage="DNI invalido." ValidationExpression="^\d{7,8}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="LblMail" runat="server" style="margin-left: 185px" Text="Email: "></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtMail" runat="server" style="margin-top: 0px" Width="480px" placeholder="ejemplo@gmail.com"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="txtMail" ErrorMessage="Email invalido." ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblTelefono" runat="server" style="margin-left: 185px" Text="Telefono:"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtTelefono" runat="server" Width="480px" placeholder=" Ejemplo: 1122223333"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Telefono invalido." ValidationExpression="^11\d{8}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblProvincia" runat="server" style="margin-left: 185px" Text="Provincia" Width="79px"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlProvincia" runat="server" Width="487px" Height="22px" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Seleccione una provincia." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblLocalidad" runat="server" style="margin-left: 183px" Text="Localidad:" Width="103px"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlLocalidad" runat="server" Width="487px" Height="22px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Seleccione una localidad." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style17">
                        <asp:TextBox ID="txtNacionalidad" runat="server" Width="480px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:RegularExpressionValidator ID="revNacion" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Nacionalidad invalida." ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]{2,12}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:TextBox ID="txtDireccion" runat="server" Width="481px" placeholder="Av. Ejemplo  2424"></asp:TextBox>
                    </td>
                    <td class="auto-style13">
                        <asp:RegularExpressionValidator ID="revDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Dirección invalida." ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ0-9\s\.\#\-]{3,60}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblNacimiento" runat="server" Text="Fecha de nacimiento:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtNacimiento" runat="server" TextMode="Date" Width="480px" placeholder="22/11/1983"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNacimiento" ErrorMessage="Ingrese una fecha de nacimiento." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table class="auto-style25">
                <tr>
                    <td class="auto-style26">
                        <asp:Label ID="lblGenero" runat="server" Text="Género:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style27">
                        <asp:RadioButtonList ID="rblGenero" runat="server">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="rblGenero" ErrorMessage="Seleccione un género." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="17px" Width="487px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style21">
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="Seleccione una especialidad." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:Label ID="lblDias" runat="server" Text="Dias de atención:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:CheckBoxList ID="cblDias" runat="server">
                            <asp:ListItem Value="0">Lunes</asp:ListItem>
                            <asp:ListItem Value="1">Martes</asp:ListItem>
                            <asp:ListItem Value="2">Miércoles</asp:ListItem>
                            <asp:ListItem Value="3">Jueves</asp:ListItem>
                            <asp:ListItem Value="4">Viernes</asp:ListItem>
                            <asp:ListItem Value="5">Sábado</asp:ListItem>
                            <asp:ListItem Value="6">Domingo</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td class="auto-style21">
                        <asp:CustomValidator ID="cvalDias" runat="server" ErrorMessage="Seleccione al menos un día." ForeColor="Red" OnServerValidate="cvalDias_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblHoraInicio" runat="server" Text="Hora de atención (inicio):" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time" Width="480px" placeholder="formato HH:MM"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvInicioHora" runat="server" ControlToValidate="txtHoraInicio" ErrorMessage="Ingrese un horario de inicio." ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="LblHoraFinal" runat="server" Text="Hora de atención (final):" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtHoraFinal" runat="server" TextMode="Time" Width="481px" placeholder="Formato HH:MM"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFinalHora" runat="server" ControlToValidate="txtHoraFinal" ErrorMessage="Ingrese un horario de finalización." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="compHoras" runat="server" ControlToCompare="txtHoraInicio" ControlToValidate="txtHoraFinal" ErrorMessage="El horario de salida no puede ser menor al de entrada." ForeColor="Red" Operator="GreaterThan"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="lblLegajo" runat="server" Text="Legajo:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style23">
                        <asp:TextBox ID="txtLegajo" runat="server" Width="481px"></asp:TextBox>
                    </td>
                    <td class="auto-style24">
                        <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Legajo invalido." ValidationExpression="^\d{4,8}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style28">
                        <asp:Label ID="lblUserMedico" runat="server" Text="Usuario médico:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style29">
                        <asp:TextBox ID="txtUserMedico" runat="server" Width="480px" placeholder="Minimo 4 caracteres, puede usar letras y numeros"></asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        <asp:RegularExpressionValidator ID="revUser" runat="server" ControlToValidate="txtUserMedico" ErrorMessage="Usuario invalido." ValidationExpression="^[A-Za-z0-9]{4,20}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="lblContraMedico" runat="server" Text="Contraseña médico:" style="margin-left: 183px"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="txtContraMedico" runat="server" Width="480px" placeholder="Debe contener minimo 8 caracteres, 1 mayuscula, 1 minuscula y 1 número."></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revContra" runat="server" ControlToValidate="txtContraMedico" ErrorMessage="Contraseña invalida." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d\@\#\$\%\!\?\&amp;]{8,30}$" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22"></td>
                    <td class="auto-style23">
                        <asp:Label ID="lblErrorVacios" runat="server" ForeColor="Red" Text="Hay campos sin completar." Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style24"></td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style15">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style15">
                        <asp:Button ID="btnAgregar" runat="server" BackColor="#3366FF" ForeColor="White" Text="Agregar Médico" Width="172px" OnClick="btnAgregar_Click" />
                    </td>
                    <td>
                        <asp:HyperLink ID="HPatras" runat="server" NavigateUrl="ABMLMedicos.aspx">Volver Atras</asp:HyperLink>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style25">
                <tr>
                    <td class="auto-style31">&nbsp;</td>
                    <td class="auto-style32">
                        <asp:Label ID="lblExito" runat="server" ForeColor="#009933" Text="Médico agregado con exito." Visible="False"></asp:Label>
                    </td>
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
