<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evaluacion.aspx.cs" Inherits="Evaluacion.evaluacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><a href="inicio.aspx">Inicio</a></p>
            <p>Tu promedio es de: </p>
            <asp:Label ID="lbAverage" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnRecomendations" runat="server" Text="Ver Recomendaciones" OnClick="btnRecomendations_Click" />
        </div>
    </form>
</body>
</html>
