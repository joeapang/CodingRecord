<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .login {
            height: 451px;
            margin-left: 502px;
            margin-top: 155px;
        }

        .auto-style1 {
            width: 30px;
            height: 25px;
        }
    </style>
</head>
<body style="background-color: gray">
    <form id="form1" runat="server">
        <div class="login">
            <div class="dg" style="width: 357px; height: 372px; background-color: #7a1541; margin-left: 0px;">

                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="教务在线系统" ForeColor="#00FFCC"></asp:Label>
                <br />
                <br />
                <br />


                &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;
                <img alt="" class="auto-style1" src="../Image/user.png" />
                <asp:TextBox ID="txtuser" runat="server" Height="29px"></asp:TextBox>
                <br />
                <br />

                &nbsp;&nbsp;&nbsp;
                
                &nbsp;&nbsp;
                <img alt="" class="auto-style1" src="../Image/password.png" />
                <asp:TextBox ID="txtpsw" runat="server" Height="31px" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt="" class="auto-style1" src="../Image/usertype.jpg" />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="29px" Width="148px">
                    <asp:ListItem>管理员</asp:ListItem>
                    <asp:ListItem>老师</asp:ListItem>
                    <asp:ListItem>学生</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/loginbutton.jpg" OnClick="ImageButton1_Click" Width="37px" />
            </div>
        </div>
    </form>
</body>
</html>
