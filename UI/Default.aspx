<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Tipo de retorno</span><br />
        <asp:RadioButtonList runat="server" ID="rbTipo">
            <asp:ListItem Value="json" Text="Json" />
            <asp:ListItem Value="objeto" Text="Objecto" />
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:LinkButton runat="server" ID="lbGoogle" Text="Login Google" OnClick="lbGoogle_OnClick" />
    </div>
    <hr />
    <div>
        <asp:Literal runat="server" ID="ltlRetorno" />
    </div>
    </form>
    <script type="text/javascript">
        try {
            // First, parse the query string
            var params = {}, queryString = location.hash.substring(1),
            regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(queryString)) {
                params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }
            var ss = queryString.split("&");
            if(ss[1] != null)
                window.location = "Default.aspx?" + ss[1];
        } catch (exp) {
            alert(exp.message);
        }
        req.send(null);
    </script>
</body>
</html>
