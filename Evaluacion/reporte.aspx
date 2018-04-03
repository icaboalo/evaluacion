<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporte.aspx.cs" Inherits="Evaluacion.reporte" %>

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
            Trabajador:  
            <asp:DropDownList ID="spNames" runat="server" OnSelectedIndexChanged="spNames_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <h2>Reporte:</h2>
            <asp:GridView ID="gvWorker" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
