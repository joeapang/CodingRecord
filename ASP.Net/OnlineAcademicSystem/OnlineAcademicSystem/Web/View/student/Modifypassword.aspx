<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Modifypassword.aspx.cs" Inherits="Web.View.student.Modifypassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div>
        <h3>修改密码</h3>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="旧密码："></asp:Label>
            <asp:TextBox ID="txt_oldpassword" runat="server" Height="24px" Width="172px" MaxLength="18" TextMode="Password"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="新密码："></asp:Label>
            <asp:TextBox ID="txt_newpassword" runat="server" Height="24px" Width="172px" MaxLength="18" TextMode="Password"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="确认密码"></asp:Label>
            <asp:TextBox ID="txt_confirm_newpassword" runat="server" Height="24px" Width="172px" MaxLength="18" TextMode="Password"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            &nbsp;&nbsp;
            <asp:Button ID="btn_ensure" runat="server" Height="33px" Text="确定" Width="67px" OnClick="btn_ensure_Click" />
&nbsp;<asp:Button ID="btn_canxel" runat="server" Height="33px" Text="取消" Width="67px" OnClick="btn_canxel_Click" />
        </p>
    </div>
</asp:Content>
