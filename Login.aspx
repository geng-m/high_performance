<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; height: 100%; margin-top: 200px">
        <table width="400" height="200" border="1" align="center">
            <tr align="center" valign="middle">
                <td>
                    用户名：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="txt_passwd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td colspan="2">
                    <asp:Button ID="btn_login" runat="server" Text="Login" 
                        onclick="btn_login_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
